using Cdcn.Domain.Entities;
using Cdcn.Domain.Repositories;
using Cdcn.Infrastructure.DataAccess.Abstractions;
using Cdcn.Infrastructure.DataAccess.Repositories.Base;
using Cdcn.Infrastructure.DataAccess.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdcn.Infrastructure.DataAccess.Repositories
{
    public sealed class CountryRepository : TableRepository<Country>, ICountryRepository
    {
        public CountryRepository(ITableContext context, IOptions<NoSqlDataAccessSetting> settings) : base(context, settings)
        {

        }
    }
}
