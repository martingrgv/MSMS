using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MSMS.Infrastructure.Constants.ValidationConstants;

namespace MSMS.Infrastructure.Data.Models;

public class TodoItem
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(TODO_NAME_MAX_LENGTH)]
    public string Name { get; set; } = null!;

    [Required]
    public bool IsCompleted { get; set; }

    [Required]
    public int TodoListId { get; set; }

    [ForeignKey(nameof(TodoListId))]
    public TodoList TodoList { get; set; } = null!;
}
