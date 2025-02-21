using Serilog;

namespace CustomTemplate.API.Configuration;

public static class LoggingExtension
{
    public static WebApplicationBuilder UseSerilog(this WebApplicationBuilder builder)
    {
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();

        builder.Host.UseSerilog(logger);
        return builder;
    }
}
