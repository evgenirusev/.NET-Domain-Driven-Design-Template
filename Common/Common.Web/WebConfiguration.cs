using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

public static class WebConfiguration
{
    public static IServiceCollection AddWebComponents(this IServiceCollection services,
        Type applicationConfigurationType)
    {
        services.AddFluentValidationAutoValidation()
            .AddValidatorsFromAssemblyContaining(applicationConfigurationType)
            .AddFluentValidationClientsideAdapters();

        return services;
    }
}