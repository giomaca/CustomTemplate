using System.Text;

namespace CustomTemplate.API.Middleware;

public class LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        var request = await FormatRequest(context.Request);
        var originalBodyStream = context.Response.Body;

        await using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        await next(context);

        var response = await FormatResponse(context.Response);

        logger.LogInformation("QueryString: {QueryString}, Request: {Request}, Response: {Response}, StatusCode: {StatusCode}",
            context.Request.QueryString,
            string.IsNullOrEmpty(request) ? "None" : request,
            string.IsNullOrEmpty(response) ? "None" : response,
            context.Response.StatusCode);

        await responseBody.CopyToAsync(originalBodyStream);
    }

    private async Task<string> FormatRequest(HttpRequest request)
    {
        request.EnableBuffering();

        var buffer = new byte[Convert.ToInt32(request.ContentLength)];
        await request.Body.ReadAsync(buffer, 0, buffer.Length);
        var bodyAsText = Encoding.UTF8.GetString(buffer);
        request.Body.Position = 0;

        return bodyAsText;
    }

    private async Task<string> FormatResponse(HttpResponse response)
    {
        response.Body.Seek(0, SeekOrigin.Begin);
        var text = await new StreamReader(response.Body).ReadToEndAsync();
        response.Body.Seek(0, SeekOrigin.Begin);

        return text;
    }
}
