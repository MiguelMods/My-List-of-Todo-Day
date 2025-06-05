using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using todo.list.domain.Entities;

namespace todo.list.persistance.Configurations;

public class PermissionEntityConfiguration : IEntityTypeConfiguration<PermissionEntity>
{
    public void Configure(EntityTypeBuilder<PermissionEntity> builder)
    {
        builder.ToTable("permissions");
        builder.HasKey(x => x.PermissionId);
        builder.Property(x => x.PermissionId).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Description).IsRequired(false).HasMaxLength(500);
        builder.Property(x => x.IsActive).HasDefaultValue(true);
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(x => x.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(50);
        builder.Property(x => x.RowGuid).IsRequired().HasDefaultValueSql("NEWID()");
        builder.HasData(
            new PermissionEntity
            {
                PermissionId = 1,
                Name = "View Todo Items",
                Description = "Permission to view todo items",
                CreatedBy = "System"
            },
            new PermissionEntity
            {
                PermissionId = 2,
                Name = "Create Todo Items",
                Description = "Permission to create todo items",
                CreatedBy = "System"
            },
            new PermissionEntity
            {
                PermissionId = 3,
                Name = "Update Todo Items",
                Description = "Permission to update todo items",
                CreatedBy = "System"
            },
            new PermissionEntity
            {
                PermissionId = 4,
                Name = "Delete Todo Items",
                Description = "Permission to delete todo items",
                CreatedBy = "System"
            },
            new PermissionEntity 
            {
                PermissionId = 5,
                Name = "Create Todo List Items",
                Description = "Permission to Create todo items",
                CreatedBy = "System"
            },
            new PermissionEntity
            {
                PermissionId = 6,
                Name = "View Todo List Items",
                Description = "Permission to View todo items",
                CreatedBy = "System"
            });
    }
}
