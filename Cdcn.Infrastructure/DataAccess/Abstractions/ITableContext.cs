using Azure.Data.Tables;
using Cdcn.Domain.Core.Data;
using Cdcn.Domain.Core.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdcn.Infrastructure.DataAccess.Abstractions
{
    public interface ITableContext
    {
        TableClient GetTableClient(string tableName);

        //Task<IEnumerable<TEntity>> QueryAsync<TEntity>(TableClient tableclient,QueryFilter<TEntity> filter) ;
    }
}
