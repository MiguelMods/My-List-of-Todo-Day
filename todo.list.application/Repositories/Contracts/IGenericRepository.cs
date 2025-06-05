using System.Linq.Expressions;
using todo.list.domain.Common;

namespace todo.list.application.Repositories.Contracts;

public interface IGenericRepository<TEntity> where TEntity : CommonEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByRowGuidAsync(string rowguid);
    Task<IEnumerable<TEntity>> GetAllByExpressionAsync(Expression<Func<TEntity, bool>> expression);
    Task<TEntity?> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(string rowguid);
}
