using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ProductsApplicationConfiguration
{
    private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();

    public static IServiceCollection PAddApplication(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddEventConsumers(Assembly)
            .AddCommonApplication(configuration, Assembly);
}