using Microsoft.EntityFrameworkCore;

namespace CustomTemplate.Persistence;

public class CustomTemplateDbContext(DbContextOptions<CustomTemplateDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("test"); // Should be changed
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomTemplateDbContext).Assembly);
    }
}
