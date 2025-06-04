using Microsoft.EntityFrameworkCore;
using todo.list.domain.Entities;
using todo.list.persistance.Configurations;

namespace todo.list.persistance.DataBaseContext;

public class TodoListDBContext(DbContextOptions<TodoListDBContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<PermissionEntity> permissionEntities { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<RolePermissionEntity> RolePermissions { get; set; }
    public DbSet<TodoItemEntity> Todos { get; set; }
    public DbSet<TodoListItemEntity> TodoLists { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PermissionEntityConfiguration());
        modelBuilder.ApplyConfiguration(new RoleEntityConfiguration());
        modelBuilder.ApplyConfiguration(new RolePermissionEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TodoItemEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TodoListItemEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
    }
}
