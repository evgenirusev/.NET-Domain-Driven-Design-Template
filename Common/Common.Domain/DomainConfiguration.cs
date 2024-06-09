using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

public static class DomainConfiguration
{
    public static IServiceCollection AddCommonDomain(
        this IServiceCollection services,
        Assembly assembly)
        => services
            .AddFactories(assembly)
            .AddInitialData(assembly);

    private static IServiceCollection AddFactories(
        this IServiceCollection services,
        Assembly assembly)
        => services
            .Scan(scan => scan
                .FromAssemblies(assembly)
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IFactory<>)))
                .AsMatchingInterface()
                .WithTransientLifetime());

    private static IServiceCollection AddInitialData(
        this IServiceCollection services,
        Assembly assembly)
        => services
            .Scan(scan => scan
                .FromAssemblies(assembly)
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IInitialData)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
}