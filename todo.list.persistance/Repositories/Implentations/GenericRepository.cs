using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using todo.list.application.Repositories.Contracts;
using todo.list.domain.Common;
using todo.list.persistance.DataBaseContext;

namespace todo.list.persistance.Repositories.Implentations;

public class GenericRepository<TEntity>(TodoListDBContext todoListDBContext) : IGenericRepository<TEntity>
    where TEntity : CommonEntity
{
    public TodoListDBContext TodoListDBContext { get; } = todoListDBContext;

    public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await TodoListDBContext.Set<TEntity>()
            .Where(x => x.IsActive && !x.IsDeleted)
            .ToListAsync();

    public async Task<TEntity?> GetByRowGuidAsync(string rowguid)
        => await TodoListDBContext.Set<TEntity>()
            .FirstOrDefaultAsync(x => x.RowGuid == rowguid && x.IsActive && !x.IsDeleted);

    public async Task<IEnumerable<TEntity>> GetAllByExpressionAsync(Expression<Func<TEntity, bool>> expression)
        => await TodoListDBContext.Set<TEntity>()
            .Where(expression)
            .Where(x => x.IsActive && !x.IsDeleted)
            .ToListAsync();

    public async Task<TEntity?> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression)
        => await TodoListDBContext.Set<TEntity>()
            .Where(expression)
            .Where(x => x.IsActive && !x.IsDeleted)
            .FirstOrDefaultAsync();

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var newEntity = await TodoListDBContext.Set<TEntity>().AddAsync(entity);
        return newEntity.Entity;
    }

    public Task<TEntity> UpdateAsync(TEntity entity)
    {
        var updatedEntity = TodoListDBContext.Set<TEntity>().Update(entity);
        return Task.FromResult(updatedEntity.Entity);
    }

    public Task<TEntity> DeleteAsync(string rowguid)
    {
        var entity = TodoListDBContext.Set<TEntity>()
            .FirstOrDefault(x => x.RowGuid == rowguid && x.IsActive && !x.IsDeleted) ?? throw new KeyNotFoundException($"Entity with RowGuid {rowguid} not found.");
        
        entity.IsActive = false;
        entity.IsDeleted = true;
        
        var deletedEntity = TodoListDBContext.Set<TEntity>().Update(entity);
        
        return Task.FromResult(deletedEntity.Entity);
    }
}
