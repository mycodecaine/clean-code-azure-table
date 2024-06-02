using Cdcn.Domain.Entities;
using Cdcn.Domain.Repositories;
using Cdcn.Infrastructure.DataAccess.Abstractions;
using Cdcn.Infrastructure.DataAccess.Repositories.Base;
using Cdcn.Infrastructure.DataAccess.Settings;
using Microsoft.Extensions.Options;

namespace Cdcn.Infrastructure.DataAccess.Repositories
{

    public  class CurrencyRepository : TableRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(ITableContext context, IOptions<NoSqlDataAccessSetting> settings) : base(context, settings)
        {

        }
    }
}
