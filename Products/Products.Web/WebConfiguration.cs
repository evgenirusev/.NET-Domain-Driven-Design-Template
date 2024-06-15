using Microsoft.Extensions.DependencyInjection;

public static class WebConfiguration
{
    public static IServiceCollection PAddWebComponents(
        this IServiceCollection services)
        => services.AddWebComponents(
            typeof(ProductsApplicationConfiguration));
}