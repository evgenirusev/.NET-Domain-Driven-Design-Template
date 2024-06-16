using System.Reflection;
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
            .AddEventHandlers(assembly)
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly))
            .AddAutoMapperProfile(assembly)
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

    private static IServiceCollection AddAutoMapperProfile(
        this IServiceCollection services, Assembly assembly)
        => services
            .AddAutoMapper(
                (_, config) => config
                    .AddProfile(new MappingProfile(assembly)),
                Array.Empty<Assembly>());
    
    private static IServiceCollection AddEventHandlers(this IServiceCollection services, Assembly assembly)
        => services
            .Scan(scan => scan
                .FromAssemblies(assembly)
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IEventHandler<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
}