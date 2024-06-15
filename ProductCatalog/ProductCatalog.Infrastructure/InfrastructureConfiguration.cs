using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class InfrastructureConfiguration
{
    private static readonly Type[] Consumers =
    [
        // Events
    ];

    public static IServiceCollection AddProductCatalogInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDBContext<ProductDbContext>(
                configuration,
                Assembly.GetExecutingAssembly())
            .AddTransient<IDbInitializer, ProductDbInitializer>();
}