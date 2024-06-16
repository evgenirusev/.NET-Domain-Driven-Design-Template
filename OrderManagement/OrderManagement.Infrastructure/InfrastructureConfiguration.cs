using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddOrderManagementInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDBStorage<OrderManagementDbContext>(
                configuration,
                Assembly.GetExecutingAssembly())
            .AddTransient<IDbInitializer, OrderManagementDbInitializer>();
}