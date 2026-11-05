using System.Text.Encodings.Web;
using System.Text.Json;

namespace ChillTechnologies.API.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = ex switch
            {
                ArgumentException or InvalidOperationException => StatusCodes.Status400BadRequest,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                KeyNotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };
            context.Response.ContentType = "application/json";

            var mensaje = context.Response.StatusCode == StatusCodes.Status500InternalServerError
                ? "Ocurrio un error interno"
                : ex.Message;

            var options = new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
            await context.Response.WriteAsync(JsonSerializer.Serialize(new { mensaje }, options));
        }
    }
}
