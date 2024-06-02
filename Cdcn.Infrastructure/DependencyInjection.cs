using Cdcn.Domain.Repositories;
using Cdcn.Infrastructure.DataAccess;
using Cdcn.Infrastructure.DataAccess.Abstractions;
using Cdcn.Infrastructure.DataAccess.Repositories;
using Cdcn.Infrastructure.DataAccess.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace Cdcn.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddOptions<NoSqlDataAccessSetting>().BindConfiguration(NoSqlDataAccessSetting.DefaultSectionName);
            services.AddSingleton<ITableContext, DbContext>();
          
            services.AddSingleton<ICountryRepository, CountryRepository>();
            services.AddSingleton<ICurrencyRepository, CurrencyRepository>();
            
            return services;
        }
    }
}
