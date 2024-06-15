using Microsoft.Extensions.DependencyInjection;

public static class WebConfiguration
{
    public static IServiceCollection OAddWebComponents(
        this IServiceCollection services)
        => services.AddWebComponents(
            typeof(OrderManagementApplicationConfiguration));
}