using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

public class ValidationExceptionHandlerMiddleware
{
    private readonly RequestDelegate next;

    public ValidationExceptionHandlerMiddleware(RequestDelegate next)
        => this.next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await this.next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;

        var result = string.Empty;

        switch (exception)
        {
            case ModelValidationException modelValidationException:
                code = HttpStatusCode.BadRequest;
                result = SerializeObject(new
                {
                    ValidationDetails = true,
                    modelValidationException.Errors
                });
                break;
            case NullReferenceException _:
                code = HttpStatusCode.BadRequest;
                result = SerializeObject(new[] { "Invalid request." });
                break;
            case NotFoundException _:
                code = HttpStatusCode.NotFound;
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        if (string.IsNullOrEmpty(result))
        {
            var error = exception.Message;

            if (exception is BaseDomainException baseDomainException)
            {
                error = baseDomainException.Error;
            }

            result = SerializeObject(new[] { error });
        }

        return context.Response.WriteAsync(result);
    }

    private static string SerializeObject(object obj)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        return JsonSerializer.Serialize(obj, options);
    }
}

public static class ValidationExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseValidationExceptionHandler(
        this IApplicationBuilder builder)
        => builder.UseMiddleware<ValidationExceptionHandlerMiddleware>();
}