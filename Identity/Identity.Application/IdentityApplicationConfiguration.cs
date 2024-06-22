using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class IdentityApplicationConfiguration
{
    public static IServiceCollection AddIdentityApplication(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddCommonApplication(
                configuration, 
                Assembly.GetExecutingAssembly());
}