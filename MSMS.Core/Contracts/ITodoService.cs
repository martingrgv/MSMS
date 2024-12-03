using MSMS.Core.Models;
using MSMS.Infrastructure.Data.Models;

namespace MSMS.Core.Contracts;

public interface ITodoService
{
    Task<TodoViewModel> AllTodosAsync(string userId);
    Task AddTodoAsync(string name, string userId);
    Task CompleteTodoAsync(int id);
    Task UncompleteTodoAsync (int id);
    Task DeleteTodoAsync(int id);
    Task DeleteAllTodosAsync(string userId);
    Task<TodoItem?> GetTodoByIdAsync(int id);
    Task<TodoList?> GetTodoListAsync(string userId);
}
