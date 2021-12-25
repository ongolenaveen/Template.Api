using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.DataProvider;
using Template.Domain.Interfaces;
using Template.Services;
using Template.Services.Interfaces;

namespace Template.Dependency.Injection
{
    public static class StartupExtension
    {
        public static void AddBindings(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IHostService, HostService>();
            services.AddScoped<IDataProviderStartup, DataProviderStartup>();
            var serviceProvider = services.BuildServiceProvider();
            var providers = serviceProvider.GetServices<IDataProviderStartup>();
            foreach (var provider in providers)
            {
                provider.AddDataProviders(services, config);
            }
        }
    }
}
