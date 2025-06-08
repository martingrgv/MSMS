namespace MSMS.Infrastructure.Data.Models;

public class TodoList
{
    public int Id { get; set; }

    public string CreatorId { get; set; } = null!;
    public ApplicationUser Creator { get; set; } = null!;

    public ICollection<TodoItem> TodoItems { get; set; } = [];
}
