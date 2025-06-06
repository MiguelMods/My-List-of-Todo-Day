using todo.list.application.Services.Contracs;
using todo.list.domain.Common;

namespace todo.list.application.Repositories.Contracts;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IGenericRepository<TEntity> GetGenericRepository<TEntity>() where TEntity : CommonEntity;
    Task<int> SaveChangesAsync();
    Task<int> SaveChangesWithTransactionAsync();
    Task RollbackAsync();
    Task CommitAsync();
}
