using CustomTemplate.API.Middleware;

namespace CustomTemplate.API.Configuration;

public static class MiddlewareExtension
{
    public static void UseMiddlewares(this WebApplication app)
    {
        app.UseMiddleware<LoggingMiddleware>();
        app.UseMiddleware<ErrorHandlingMiddleware>();
    }
}
