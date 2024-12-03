using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MSMS.Infrastructure.Constants.ValidationConstants;

namespace MSMS.Infrastructure.Data.Models;

public class TodoList
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string CreatorId { get; set; } = null!;

    [ForeignKey(nameof(CreatorId))]
    public ApplicationUser Creator { get; set; } = null!;

    public ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
}
