using Azure.Data.Tables;
using Cdcn.Domain.Core.Data;
using Cdcn.Domain.Core.Persistence;
using Cdcn.Domain.Core.Primitives;
using Cdcn.Infrastructure.DataAccess.Abstractions;
using Cdcn.Infrastructure.DataAccess.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdcn.Infrastructure.DataAccess.Repositories.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>, IUnitOfWork where TEntity : class, ITableEntity, new()
    {
        private readonly TableClient _tableClient;
        private readonly List<TableTransactionAction> _transactionActions;
        protected readonly ITableContext _context;
        protected readonly NoSqlDataAccessSetting _settings;
        protected readonly string _tableName;

        //public GenericRepository(TableClient tableClient)
        //{
        //    _tableClient = tableClient;
        //    _transactionActions = new List<TableTransactionAction>();
        //}

        protected GenericRepository(ITableContext context, IOptions<NoSqlDataAccessSetting> settings)
        {
            _tableName = typeof(TEntity).Name;
            _context = context;
            _settings = settings.Value;

            _tableClient = _context.GetTableClient(_tableName);
            _transactionActions = new List<TableTransactionAction>();
        }

        public async Task<TEntity> GetAsync(string partitionKey, string rowKey)
        {
            var entity = await _tableClient.GetEntityAsync<TEntity>(partitionKey, rowKey);
            return entity.Value;
        }

        public Task InsertAsync(TEntity entity)
        {
            _transactionActions.Add(new TableTransactionAction(TableTransactionActionType.Add, entity));
            return Task.CompletedTask;
        }

        public Task UpdateAsync(TEntity entity)
        {
            _transactionActions.Add(new TableTransactionAction(TableTransactionActionType.UpdateReplace, entity));
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TEntity entity)
        {
            _transactionActions.Add(new TableTransactionAction(TableTransactionActionType.Delete, entity));
            return Task.CompletedTask;
        }

        public async Task CommitAsync()
        {
            if (_transactionActions.Any())
            {
                await _tableClient.SubmitTransactionAsync(_transactionActions);
                _transactionActions.Clear();
            }
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            // Scan the table for the entity with the specified Id
            var entities = _tableClient.QueryAsync<TEntity>(entity => entity.RowKey == id.ToString() && entity.PartitionKey == _tableName);

            // Assuming the Id is unique and only one entity will be found
            await foreach (var entity in entities)
            {
                return entity;
            }
            return null;
        }

        public async Task Delete(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
                await DeleteAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> QueryAsync(QueryFilter<TEntity> filter)
        {
            var data = _tableClient.QueryAsync(filter.Combine());
            var entities = new List<TEntity>();

            await foreach (var entity in data)
            {
                entities.Add(entity);
            }
            return entities;
        }

        public async Task<bool> IsUniqeAsync(QueryFilter<TEntity> filter)
        {
            var data = _tableClient.QueryAsync(filter.Combine());

            await foreach (var entity in data)
            {
                return false;
            }
            return true;
        }

        public void Dispose()
        {

        }
    }

}
