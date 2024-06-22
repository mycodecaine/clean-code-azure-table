using Azure.Data.Tables;
using Cdcn.Domain.Core.Data;
using Cdcn.Domain.Core.Persistence;
using Cdcn.Infrastructure.DataAccess.Abstractions;
using Cdcn.Infrastructure.DataAccess.Settings;
using Cdcn.Infrastructure.DataAccess.Specifications;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Cdcn.Infrastructure.DataAccess.Repositories.Base
{
    public abstract class TableRepository<TEntity> : IRepository<TEntity>
       where TEntity : Domain.Core.Primitives.Entity
    {
        protected readonly ITableContext _context;
        protected readonly NoSqlDataAccessSetting _settings;
        private readonly TableClient _tableClient;
        protected readonly string _tableName;

        protected TableRepository(ITableContext context, IOptions<NoSqlDataAccessSetting> settings)
        {
            _tableName = typeof(TEntity).Name;
            _context = context;
            _settings = settings.Value;

            _tableClient = _context.GetTableClient(_tableName);
        }
        public async Task<TEntity?> GetByIdAsync(Guid id)
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



        public async Task Insert(TEntity entity)
        {

            await _tableClient.AddEntityAsync(entity);
        }

        public async Task Remove(TEntity entity)
        {
            await _tableClient.DeleteEntityAsync(entity.PartitionKey, entity.RowKey);
        }

        public async Task Update(TEntity entity)
        {
            await _tableClient.UpdateEntityAsync(entity, entity.ETag, TableUpdateMode.Replace);

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

        

        public async Task Delete(Guid id)
        {
            var entity = await GetByIdAsync(id);
            await Remove(entity);
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
    }
}
