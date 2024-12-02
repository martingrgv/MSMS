using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MSMS.Infrastructure.Constants.ValidationConstants;

namespace MSMS.Infrastructure.Data.Models;

public class TodoList
{
    [Key]
    public int Id { get; set; }

    [MaxLength(TODO_LIST_NAME_MAX_LENGTH)]
    public string Name { get; set; } = null!;

    [Required]
    public string CreatorId { get; set; } = null!;

    [ForeignKey(nameof(CreatorId))]
    public ApplicationUser Creator { get; set; } = null!;

    public ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
}
