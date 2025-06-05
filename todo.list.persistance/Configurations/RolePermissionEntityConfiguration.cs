using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using todo.list.domain.Entities;

namespace todo.list.persistance.Configurations;

public class RolePermissionEntityConfiguration : IEntityTypeConfiguration<RolePermissionEntity> 
{
    public void Configure(EntityTypeBuilder<RolePermissionEntity> builder)
    {
        builder.ToTable("rolePermissions");
        builder.HasKey(x => x.RolePermissionId);
        builder.Property(x => x.RolePermissionId).ValueGeneratedOnAdd();
        builder.Property(x => x.RoleId).IsRequired();
        builder.Property(x => x.PermissionId).IsRequired();
        builder.HasOne(x => x.Role)
            .WithMany(r => r.RolePermissions)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Permission)
            .WithMany()
            .HasForeignKey(x => x.PermissionId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(x => x.IsActive).HasDefaultValue(true);
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(x => x.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(50);
        builder.Property(x => x.RowGuid).IsRequired().HasDefaultValueSql("NEWID()");
        builder.HasData(new RolePermissionEntity
        {
            RolePermissionId = 1,
            RoleId = 1, // Generic role
            PermissionId = 1, // View Todo Items
            CreatedBy = "System"
        }, new RolePermissionEntity
        {
            RolePermissionId = 2,
            RoleId = 1, // Generic role
            PermissionId = 2, // Create Todo Items
            CreatedBy = "System"
        }, new RolePermissionEntity
        {
            RolePermissionId = 3,
            RoleId = 1, // Generic role
            PermissionId = 3, // Update Todo Items
            CreatedBy = "System"
        }, new RolePermissionEntity
        {
            RolePermissionId = 4,
            RoleId = 1, // Generic role
            PermissionId = 4, // Delete Todo Items
            CreatedBy = "System"
        }, new RolePermissionEntity
        {
            RolePermissionId = 5,
            RoleId = 2, // Administrator role
            PermissionId = 5, // Create Todo List Items
            CreatedBy = "System"
        });
    }
}