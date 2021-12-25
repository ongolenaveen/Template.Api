using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.Domain.Interfaces;

namespace Template.DataProvider
{
    public class DataProviderStartup : IDataProviderStartup
    {
        public IServiceCollection AddDataProviders(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IHostDataProvider, HostDataProvider>();
            return services;
        }
    }
}
