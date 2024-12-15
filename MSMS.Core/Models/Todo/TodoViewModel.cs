using System;

namespace MSMS.Core.Models;

public class TodoViewModel
{
    public IEnumerable<TodoItemViewModel> Todos { get; set; } = new List<TodoItemViewModel>();
    public TodoCreateModel TodoCreateModel { get; set; } = null!;
}
