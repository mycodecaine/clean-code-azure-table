using Azure.Data.Tables;
using Cdcn.Domain.Core.Data;
using Cdcn.Domain.Core.Primitives;
using Cdcn.Domain.Entities;
using Cdcn.Domain.Repositories;
using Cdcn.Infrastructure.DataAccess.Abstractions;
using Cdcn.Infrastructure.DataAccess.Repositories.Base;
using Cdcn.Infrastructure.DataAccess.Settings;
using Cdcn.Infrastructure.DataAccess.Specifications;
using Microsoft.Extensions.Options;

namespace Cdcn.Infrastructure.DataAccess.Repositories
{

    public  class CurrencyRepository : TableRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(ITableContext context, IOptions<NoSqlDataAccessSetting> settings) : base(context, settings)
        {

        }

        public async Task<bool> IsCodeUniqueAsync(string code)
        {
            var filter = new QueryFilter<Currency>();
            filter.Add(x => x.Code== code);
            filter.Add(x => x.PartitionKey == nameof(Currency));

            return await base.IsUniqeAsync(filter);
           

        }

        
    }
}
