using CustomTemplate.Domain.Exceptions;
using FluentResults;
using Newtonsoft.Json;
using System.Net;

namespace CustomTemplate.API.Middleware;

public class ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        Error? res;
        switch (ex)
        {
            case DomainException:
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                res = new Error(ex.Message);
                break;
            default:
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                res = new Error(ex.Message);
                break;
        }
        await context.Response.WriteAsync(JsonConvert.SerializeObject(res));
    }
}
