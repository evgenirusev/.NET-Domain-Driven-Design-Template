using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class InfrastructureConfiguration
{
    private static readonly Type[] Consumers =
    [
        // Events
    ];

    public static IServiceCollection AddOrderManagementInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDBContext<OrderManagementDbContext>(
                configuration,
                Assembly.GetExecutingAssembly())
            .AddTransient<IDbInitializer, OrderManagementDbInitializer>();
}