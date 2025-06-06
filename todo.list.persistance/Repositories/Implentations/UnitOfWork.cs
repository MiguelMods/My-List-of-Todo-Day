using todo.list.application.Repositories.Contracts;
using todo.list.domain.Common;
using todo.list.persistance.DataBaseContext;

namespace todo.list.persistance.Repositories.Implentations;

public class UnitOfWork(TodoListDBContext todoListDBContext) : IUnitOfWork
{
    private readonly TodoListDBContext TodoListDBContext = todoListDBContext;

    public IUserRepository UserRepository => new UserRepository(TodoListDBContext);

    public IGenericRepository<TEntity> GetGenericRepository<TEntity>() where TEntity : CommonEntity => new GenericRepository<TEntity>(TodoListDBContext);

    public async Task<int> SaveChangesAsync()
    {
        var result = await TodoListDBContext.SaveChangesAsync();
        return result;
    }

    public async Task<int> SaveChangesWithTransactionAsync()
    {
        await using var transaction = await TodoListDBContext.Database.BeginTransactionAsync();
        try
        {
            var result = await TodoListDBContext.SaveChangesAsync();
            await transaction.CommitAsync();
            return result;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task CommitAsync()
    {
        if (TodoListDBContext.Database.CurrentTransaction != null)
        {
            await TodoListDBContext.Database.CommitTransactionAsync();
        }
    }

    public async Task RollbackAsync()
    {
        if (TodoListDBContext.Database.CurrentTransaction != null)
        {
            await TodoListDBContext.Database.RollbackTransactionAsync();
        }
    }

    public async void Dispose()
    {
        await TodoListDBContext.DisposeAsync();
        GC.SuppressFinalize(this); // Fix for CA1816
    }
}
