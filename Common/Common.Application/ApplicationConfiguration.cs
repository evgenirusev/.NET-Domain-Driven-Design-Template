using System.Reflection;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddCommonApplication(
        this IServiceCollection services,
        IConfiguration configuration,
        Assembly assembly)
        => services
            .Configure<ApplicationSettings>(
                configuration.GetSection(nameof(ApplicationSettings)),
                options => options.BindNonPublicProperties = true)
            .AddMediatR(assembly)
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

    public static IServiceCollection AddEventConsumers(
        this IServiceCollection services,
        Assembly assembly)
        => services
            .Scan(scan => scan
                .FromAssemblies(assembly)
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IConsumer<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
}