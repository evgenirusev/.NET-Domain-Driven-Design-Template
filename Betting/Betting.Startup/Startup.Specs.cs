namespace BettingSystem.Startup.Betting;

using Application.Betting.Bets;
using Domain.Betting.Factories.Bets;
using MediatR;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class StartupSpecs : Startup
{
    public StartupSpecs(IConfiguration configuration) 
        : base(configuration)
    {
    }

    public void ConfigureTestServices(IServiceCollection services)
    {
        base.ConfigureServices(services);

        ValidateServices(services);
    }

    private static void ValidateServices(IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();

        provider.GetRequiredService<IBetFactory>();
        provider.GetRequiredService<IMediator>();
        provider.GetRequiredService<IBetQueryRepository>();
        provider.GetRequiredService<IControllerFactory>();
    }
}