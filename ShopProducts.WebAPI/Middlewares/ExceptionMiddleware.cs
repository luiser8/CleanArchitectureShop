using ShopProducts.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace ShopProducts.WebAPI.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
    
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
    
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                await ManagementException(context, ex);
            }
        }

    private Task ManagementException(HttpContext context, Exception ex)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        var result = string.Empty;

        switch(ex)
        {
            case ExceptionBusinessRule businessRule:
                statusCode = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(businessRule.Message);
                break;
            case ExceptionNotFound notFound:
                statusCode = HttpStatusCode.NotFound;
                result = JsonSerializer.Serialize(notFound.Message);
                break;
        }
        context.Response.StatusCode = (int)statusCode;
        return context.Response.WriteAsync(result);

    }
}

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
}
