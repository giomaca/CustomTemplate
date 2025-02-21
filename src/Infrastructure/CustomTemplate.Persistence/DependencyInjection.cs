using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomTemplate.Persistence;

public static class DependencyInjection
{
    public static void AddCustomTemplateDbContext(this IServiceCollection services, string connectionString) =>
    services.AddDbContext<CustomTemplateDbContext>(options =>
         options.UseNpgsql(connectionString));
}