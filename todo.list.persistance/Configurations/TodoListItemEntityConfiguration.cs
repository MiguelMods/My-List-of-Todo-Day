using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using todo.list.domain.Entities;

namespace todo.list.persistance.Configurations;

public class TodoListItemEntityConfiguration : IEntityTypeConfiguration<TodoListItemEntity>
{
    public void Configure(EntityTypeBuilder<TodoListItemEntity> builder)
    {
        builder.ToTable("todoListItems");
        builder.HasKey(x => x.TodoListItemId);
        builder.Property(x => x.TodoListItemId).ValueGeneratedOnAdd();
        builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Description).IsRequired(false).HasMaxLength(500);
        builder.Property(x => x.IsCompleted).HasDefaultValue(false);
        builder.Property(x => x.IsActive).HasDefaultValue(true);
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(x => x.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(50);
        builder.Property(x => x.RowGuid).IsRequired().HasDefaultValueSql("NEWID()");
        builder.HasMany(x => x.TodoItemEntities)
            .WithOne()
            .HasForeignKey(x => x.TodoListItemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
