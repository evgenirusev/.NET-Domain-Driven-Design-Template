using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddProductCatalogInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDBStorage<ProductDbContext>(
                configuration,
                Assembly.GetExecutingAssembly())
            .AddTransient<IDbInitializer, ProductDbInitializer>();
}