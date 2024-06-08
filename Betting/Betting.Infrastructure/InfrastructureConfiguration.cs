namespace BettingSystem.Infrastructure.Betting;

using System;
using System.Reflection;
using Application.Betting.Matches.Consumers;
using Common;
using Common.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

public static class InfrastructureConfiguration
{
    private static readonly Type[] Consumers =
    {
        typeof(MatchCreatedEventConsumer),
        typeof(MatchStatusUpdatedEventConsumer),
        typeof(MatchStartDateUpdatedEventConsumer),
        typeof(MatchStatisticsUpdatedEventConsumer)
    };

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddEvents(
                configuration,
                usePolling: false,
                consumers: Consumers)
            .AddCommonInfrastructure<BettingDbContext>(
                configuration,
                Assembly.GetExecutingAssembly())
            .AddTransient<IDbInitializer, BettingDbInitializer>();
}