using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

internal sealed class NotFoundExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not NotFoundException ex)
        {
            return false;
        }

        httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
        httpContext.Response.ContentType = "application/json";

        var body = JsonSerializer.Serialize(new[] { ex.Message });

        await httpContext.Response.WriteAsync(body, cancellationToken);
        return true;
    }
}
