using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using todo.list.domain.Entities;

namespace todo.list.persistance.Configurations;

public class TodoItemEntityConfiguration : IEntityTypeConfiguration<TodoItemEntity>
{
    public void Configure(EntityTypeBuilder<TodoItemEntity> builder)
    {
        builder.ToTable("todoItems");
        builder.HasKey(x => x.TodoItemId);
        builder.Property(x => x.TodoItemId).ValueGeneratedOnAdd();
        builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
        builder.Property(x => x.IsCompleted).HasDefaultValue(false);
        builder.Property(x => x.StartAt).IsRequired(false).HasColumnType("datetime");
        builder.Property(x => x.EndAt).IsRequired(false).HasColumnType("datetime");
        builder.Property(x => x.CompletedAt).IsRequired(false).HasColumnType("datetime");
        builder.Property(x => x.IsActive).HasDefaultValue(true);
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(x => x.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(50);
        builder.Property(x => x.RowGuid).IsRequired().HasDefaultValueSql("NEWID()");
    }
}
