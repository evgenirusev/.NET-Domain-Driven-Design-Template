namespace BettingSystem.Startup.Betting;

using Application.Betting;
using Domain.Betting;
using Infrastructure.Betting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Betting;
using Web.Common.Extensions;

public class Startup
{
    public Startup(IConfiguration configuration)
        => this.Configuration = configuration;

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
        => services
            .AddDomain()
            .AddApplication(this.Configuration)
            .AddInfrastructure(this.Configuration)
            .AddWebComponents();

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        => app
            .UseWebService(env)
            .Initialize();
}