using CustomTemplate.Domain.Primitives;
using CustomTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomTemplate.Persistence.Repositories;

public class Repository<T>(CustomTemplateDbContext dbContext) : IRepository<T> where T : Entity
{
    private readonly DbSet<T> _dbSet = dbContext.Set<T>();

    public IQueryable<T> GetAsync() => _dbSet.AsQueryable();

    public async Task<T?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public Task UpdateAsync(T entity)
    {
        dbContext.Entry(entity).State = EntityState.Modified;
        return Task.CompletedTask;
    }
}
