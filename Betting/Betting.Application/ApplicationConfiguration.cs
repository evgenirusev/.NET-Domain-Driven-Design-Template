namespace BettingSystem.Application.Betting;

using System.Reflection;
using Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationConfiguration
{
    private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();

    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddEventConsumers(Assembly)
            .AddCommonApplication(configuration, Assembly);
}