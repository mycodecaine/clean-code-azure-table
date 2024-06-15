using Azure.Data.Tables;
using Cdcn.Domain.Core.Data;
using Cdcn.Infrastructure.DataAccess.Abstractions;
using Cdcn.Infrastructure.DataAccess.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdcn.Infrastructure.DataAccess
{
    internal class DbContext : ITableContext
    {
        private readonly NoSqlDataAccessSetting _noSqlDataAccessSetting;
        private readonly TableServiceClient _tableServiceClient;

        public DbContext(IOptions<NoSqlDataAccessSetting> noSqlDataAccessSetting)
        {
            _noSqlDataAccessSetting = noSqlDataAccessSetting.Value;
            _tableServiceClient = new TableServiceClient(_noSqlDataAccessSetting.ConnectionString);
        }

        public TableClient GetTableClient(string tableName)
        {
            var tableClient = _tableServiceClient.GetTableClient(tableName);
            tableClient.CreateIfNotExists();
            return tableClient;

           
        }

        public Task<IEnumerable<TEntity>> QueryAsync<TEntity>(TableClient tableclient, QueryFilter<TEntity> filter)
        {
            throw new NotImplementedException();
        }
    }
}
