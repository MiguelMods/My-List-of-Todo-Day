using System.Linq.Expressions;
using todo.list.application.Repositories.Contracts;
using todo.list.application.Services.Contracts;
using todo.list.domain.Common;

namespace todo.list.application.Services.Implementations;

public abstract class GenericService<TEntity>(IUnitOfWork unitOfWork) : IGenericService<TEntity> where TEntity : CommonEntity
{
    public IUnitOfWork UnitOfWork { get; } = unitOfWork;
    public IGenericRepository<TEntity> Repository { get; } = unitOfWork.GetGenericRepository<TEntity>();

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        => await Repository.GetAllAsync();

    public virtual async Task<TEntity?> GetByRowGuidAsync(string rowguid)
        => await Repository.GetByRowGuidAsync(rowguid);

    public virtual async Task<IEnumerable<TEntity>> GetAllByExpressionAsync(Expression<Func<TEntity, bool>> expression)
        => await Repository.GetAllByExpressionAsync(expression);

    public virtual async Task<TEntity?> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression)
        => await Repository.GetByExpressionAsync(expression);

    public virtual async Task<TEntity> AddAsync(TEntity entity) 
    {
        var addedEntity = await Repository.AddAsync(entity);

        var rowAffect = await UnitOfWork.SaveChangesAsync();

        if (rowAffect <= 0)
            throw new Exception("Failed to add entity to the database.");

        return addedEntity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity) 
    {
        var updatedEntity = await Repository.UpdateAsync(entity);
        
        var rowAffect = await UnitOfWork.SaveChangesAsync();
        
        if (rowAffect <= 0)
            throw new Exception("Failed to update entity in the database.");
        
        return updatedEntity;
    }

    public virtual async Task<TEntity> DeleteAsync(string rowguid)
        => await Repository.DeleteAsync(rowguid);
}
