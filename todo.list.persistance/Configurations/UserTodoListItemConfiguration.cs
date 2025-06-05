using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using todo.list.domain.Entities;

namespace todo.list.persistance.Configurations;

public class UserTodoListItemConfiguration : IEntityTypeConfiguration<UserTodoListItem>
{
    public void Configure(EntityTypeBuilder<UserTodoListItem> builder)
    {
        builder.ToTable("userTodoListItems");
        builder.HasKey(x => x.UserTodoListItemId);
        builder.Property(x => x.UserTodoListItemId).ValueGeneratedOnAdd();
        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.TodoListItemId).IsRequired();
        builder.HasOne(x => x.User)
            .WithMany(x => x.TodoListItems)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.TodoListItem);
        builder.Property(x => x.TodoListItemId)
            .IsRequired()
            .HasColumnName("TodoListItemId");
        builder.Property(x => x.IsActive).HasDefaultValue(true);
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(x => x.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(50);
        builder.Property(x => x.RowGuid).IsRequired().HasDefaultValueSql("NEWID()");
    }
}