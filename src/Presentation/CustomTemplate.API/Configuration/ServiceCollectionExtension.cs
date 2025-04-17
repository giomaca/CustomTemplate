using CustomTemplate.Application;
using CustomTemplate.Domain.Repositories;
using CustomTemplate.Persistence;
using CustomTemplate.Persistence.Repositories;
using Mapster;
using MapsterMapper;

namespace CustomTemplate.API.Configuration;

public static class ServiceCollectionExtension
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCustomTemplateDbContext(configuration.GetConnectionString("DefaultConnection")!);
        services.AddRepositories();
        services.AddSettings(configuration);
        services.AddApplication();
        services.AddMapper();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static void AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
    }

    private static void AddMapper(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Application.AssemblyReference.Assembly, API.AssemblyReference.Assembly);

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
    }
}
