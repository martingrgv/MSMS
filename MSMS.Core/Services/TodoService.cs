using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MSMS.Core.Contracts;
using MSMS.Core.Models;
using MSMS.Infrastructure.Common;
using MSMS.Infrastructure.Data.Models;

namespace MSMS.Core.Services;

public class TodoService : ITodoService
{
    private readonly IRepository _repository;
    private readonly IMapper _mapper;

    public TodoService(IRepository repository, IMapper mapper)
    {
        _repository = repository;  
        _mapper = mapper;
    }

    public async Task AddTodoAsync(string name, string userId)
    {
        var todoList = await GetTodoListAsync(userId);

        if (todoList == null)
        {
            todoList = new TodoList{
                CreatorId = userId
            };
            await _repository.AddAsync(todoList);
        }

        todoList.TodoItems.Add(new TodoItem
        {
            Name = name,
            IsCompleted = false,
        });

        await _repository.SaveChangesAsync();
    }

    public async Task<TodoViewModel> AllTodosAsync(string userId)
    {
        var todoList = await _repository.AllReadOnly<TodoList>().Include(t => t.TodoItems).FirstOrDefaultAsync(tl => tl.CreatorId == userId);

        if (todoList == null)
        {
            return new TodoViewModel();
        }

        var todosViewModel = _mapper.Map<TodoViewModel>(todoList);
        return todosViewModel;
    }

    public async Task CompleteTodoAsync(int id)
    {
        var todo = await GetTodoByIdAsync(id);

        if (todo == null)
        {
            return;
        }

        todo.IsCompleted = true;
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAllTodosAsync(string userId)
    {
        var todoList = await GetTodoListAsync(userId);

        if (todoList == null)
        {
            return;
        }

        var completedTasks = todoList.TodoItems.Where(t => t.IsCompleted).ToList();
        await _repository.RemoveRangeAsync(completedTasks);
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteTodoAsync(int id)
    {
        var todo = await GetTodoByIdAsync(id);

        if (todo == null)
        {
            return;
        }

        await _repository.RemoveAsync(todo);
        await _repository.SaveChangesAsync();
    }

    public async Task<TodoItem?> GetTodoByIdAsync(int id)
    {
        return await _repository.GetByIdAsync<TodoItem>(id);
    }

    public async Task<TodoList?> GetTodoListAsync(string userId)
    {
        return await _repository.All<TodoList>().Include(l => l.TodoItems).FirstOrDefaultAsync(t => t.CreatorId == userId);
    }

    public async Task UncompleteTodoAsync(int id)
    {
        var todo = await GetTodoByIdAsync(id);

        if (todo == null)
        {
            return;
        }

        todo.IsCompleted = false;
        await _repository.SaveChangesAsync();
    }
}
