using Azure.Data.Tables;
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
    }
}
