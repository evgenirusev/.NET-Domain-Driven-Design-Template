using Microsoft.Extensions.DependencyInjection;

public static class WebConfiguration
{
    public static IServiceCollection AddProductCatalogWebComponents(
        this IServiceCollection services)
        => services.AddWebComponents(
            typeof(ProductsApplicationConfiguration));
}