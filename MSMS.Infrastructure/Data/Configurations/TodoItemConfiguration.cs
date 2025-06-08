using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSMS.Infrastructure.Data.Models;
using static MSMS.Infrastructure.Constants.ValidationConstants;

namespace MSMS.Infrastructure.Data.Configurations;

public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(TODO_ITEM_NAME_MAX_LENGTH)
            .IsRequired();

        builder.Property(x => x.IsCompleted)
            .HasDefaultValue(false);

        builder.HasOne(x => x.TodoList)
            .WithMany(x => x.TodoItems)
            .HasForeignKey(x => x.TodoListId)
            .IsRequired();
    }
}
