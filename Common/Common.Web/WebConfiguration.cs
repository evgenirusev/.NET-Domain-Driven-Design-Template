using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

public static class WebConfiguration
{
    public static IServiceCollection AddCommonWebComponents(this IServiceCollection services,
        Type applicationConfigurationType)
    {
        services.Configure<ApiBehaviorOptions>(options => options
                .SuppressModelStateInvalidFilter = true);
        services.AddControllers(options => options
            .ModelBinderProviders
            .Insert(0, new ImageModelBinderProvider()));
        services.AddFluentValidationAutoValidation()
            .AddValidatorsFromAssemblyContaining(applicationConfigurationType)
            .AddFluentValidationClientsideAdapters();
        
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "Web API", Version = "v1" });
        });

        return services;
    }
}