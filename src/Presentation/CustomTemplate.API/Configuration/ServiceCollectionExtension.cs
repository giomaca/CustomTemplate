using CustomTemplate.API.Middleware;
using CustomTemplate.Domain.Repositories;
using CustomTemplate.Persistence.Repositories;

namespace CustomTemplate.API.Configuration;

public static class ServiceCollectionExtension
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void AddServices(this IServiceCollection services)
    {
    }

    public static void AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
    }

    public static void UseMiddlewares(this WebApplication app)
    {
        app.UseMiddleware<LoggingMiddleware>();
        app.UseMiddleware<ErrorHandlingMiddleware>();
    }
}
