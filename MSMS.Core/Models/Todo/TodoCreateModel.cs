using System.ComponentModel.DataAnnotations;
using static MSMS.Infrastructure.Constants.ValidationConstants;

namespace MSMS.Core.Models;

public class TodoCreateModel
{
    [Required]
    [StringLength(TODO_ITEM_NAME_MAX_LENGTH, MinimumLength = TODO_ITEM_NAME_MIN_LENGTH, ErrorMessage = "Todo must be between {0} and {1} characters long!")]
    public string Name { get; set; } = null!;
}
