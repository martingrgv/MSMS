using System;

namespace MSMS.Core.Models;

public class TodoItemViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool isCompleted { get; set; }
}
