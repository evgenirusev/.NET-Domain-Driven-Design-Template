using Microsoft.Extensions.DependencyInjection;

public static class WebConfiguration
{
    public static IServiceCollection AddOrderManagementWebComponents(
        this IServiceCollection services)
        => services.AddWebComponents(
            typeof(OrderManagementApplicationConfiguration));
}