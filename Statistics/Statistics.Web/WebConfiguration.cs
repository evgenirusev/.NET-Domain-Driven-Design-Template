using Microsoft.Extensions.DependencyInjection;

public static class WebConfiguration
{
    public static IServiceCollection AddStatisticsWebComponents(
        this IServiceCollection services)
        => services.AddWebComponents(
            typeof(StatisticsApplicationConfiguration));
}