using CustomTemplate.Domain.Primitives;

namespace CustomTemplate.Domain.Repositories;

public interface IRepository<T> where T : Entity
{
    IQueryable<T> GetAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
}
