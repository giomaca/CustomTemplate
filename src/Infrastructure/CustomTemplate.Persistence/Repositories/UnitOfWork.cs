using CustomTemplate.Domain.Primitives;
using CustomTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace CustomTemplate.Persistence.Repositories;

public class UnitOfWork(CustomTemplateDbContext dbContext) : IUnitOfWork
{
    private readonly Dictionary<Type, object> _repositories = [];
    private IDbContextTransaction? _transaction;

    public IRepository<T> GetRepository<T>() where T : Entity
    {
        if (_repositories.ContainsKey(typeof(T)))
        {
            return (IRepository<T>)_repositories[typeof(T)];
        }

        var repository = new Repository<T>(dbContext);
        _repositories.Add(typeof(T), repository);
        return repository;
    }

    public async Task<int> SaveChangesAsync() => await dbContext.SaveChangesAsync();

    public async Task BeginTransactionAsync() => _transaction = await dbContext.Database.BeginTransactionAsync();

    public async Task CommitAsync()
    {
        if (_transaction is not null)
        {
            try
            {
                await SaveChangesAsync();
                await _transaction.CommitAsync();

            }
            catch
            {
                await RollbackAsync();
                throw;
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }

    public async Task RollbackAsync()
    {
        if (_transaction is not null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            dbContext.Dispose();
        }
    }
}
