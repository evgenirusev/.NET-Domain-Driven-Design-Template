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
            .AddTransient<IDbInitializer, OrderManagementDbInitializer>()
            .AddHttpClients(configuration);

    public static IServiceCollection AddHttpClients(
        this IServiceCollection services,
        IConfiguration configuration)
        => services.AddHttpClient<ProductCatalogHttpService>(httpClient =>
            {
                var httpClientSettings = configuration.GetOrderManagementSettings();
                httpClient.BaseAddress = new Uri(httpClientSettings.ProductCatalogAPIClientSettings.BaseUrl);
            })
            .ConfigureDefaultHttpClientHandler()
            .AddTypedClient<IProductCatalogHttpService, ProductCatalogHttpService>()
            .Services;
}