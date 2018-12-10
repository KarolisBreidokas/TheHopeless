using Microsoft.Extensions.DependencyInjection;
using TheHopeless.API.Services;
using TheHopeless.API.Services.Implementations;

namespace TheHopeless.API.Configurations
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddAllDependencies(this IServiceCollection service)
        {
            return service
                .AddInfrastructureDependencies()
                .AddApplicationDependencies();
        }

        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection service)
        {
            return service;

        }

        public static IServiceCollection AddApplicationDependencies(this IServiceCollection service)
        {
            return service.AddScoped<IProductService, ProductService>();
        }

    }
}
