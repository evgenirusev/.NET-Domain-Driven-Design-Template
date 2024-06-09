using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class InfrastructureConfiguration
{
    private static readonly Type[] Consumers =
    {
        // Events
    };

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddEvents(
                configuration,
                usePolling: false,
                consumers: Consumers)
            .AddCommonInfrastructure<ProductDbContext>(
                configuration,
                Assembly.GetExecutingAssembly())
            .AddTransient<IDbInitializer, ProductDbInitializer>();
}