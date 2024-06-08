namespace BettingSystem.Infrastructure.Betting;

using System;
using System.Reflection;
using Application.Betting.Bets;
using Application.Betting.Gamblers;
using Common;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Xunit;

public class InfrastructureConfigurationSpecs
{
    [Fact]
    public void AddRepositoriesShouldRegisterRepositories()
    {
        var serviceCollection = new ServiceCollection()
            .AddDbContext<BettingDbContext>(options => options
                .UseInMemoryDatabase(Guid.NewGuid().ToString()));

        var assembly = Assembly.GetExecutingAssembly();

        var services = serviceCollection
            .AddAutoMapper(assembly)
            .AddRepositories(assembly)
            .BuildServiceProvider();

        services
            .GetService<IBetQueryRepository>()
            .Should()
            .NotBeNull();

        services
            .GetService<IGamblerQueryRepository>()
            .Should()
            .NotBeNull();
    }
}