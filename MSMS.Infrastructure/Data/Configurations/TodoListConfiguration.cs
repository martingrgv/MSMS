using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSMS.Infrastructure.Data.Models;

namespace MSMS.Infrastructure.Data.Configurations;

public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
{
    public void Configure(EntityTypeBuilder<TodoList> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Creator)
            .WithMany(x => x.TodoLists)
            .HasForeignKey(x => x.CreatorId)
            .IsRequired();
    }
}
