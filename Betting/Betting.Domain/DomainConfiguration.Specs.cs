namespace BettingSystem.Domain.Betting;

using Factories.Bets;
using Factories.Gamblers;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

public class DomainConfigurationSpecs
{
    [Fact]
    public void AddDomainShouldRegisterFactories()
    {
        var serviceCollection = new ServiceCollection();

        var services = serviceCollection
            .AddDomain()
            .BuildServiceProvider();

        services
            .GetService<IBetFactory>()
            .Should()
            .NotBeNull();

        services
            .GetService<IGamblerFactory>()
            .Should()
            .NotBeNull();
    }
}