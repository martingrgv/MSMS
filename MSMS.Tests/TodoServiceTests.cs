using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using MSMS.Core.Contracts;
using MSMS.Core.Models;
using MSMS.Core.Services;
using MSMS.Infrastructure.Common;
using MSMS.Infrastructure.Data.Models;
using MSMS.Tests.Extensions;
using System.Linq.Expressions;

namespace MSMS.Tests
{
    public class TodoServiceTests
    {
        private Mock<IRepository> repositoryMock;
        private Mock<IMapper> mapperMock;
        private ITodoService todoService;

        [SetUp]
        public void Setup()
        {
            repositoryMock = new Mock<IRepository>();
            mapperMock = new Mock<IMapper>();
            todoService = new TodoService(repositoryMock.Object, mapperMock.Object);
        }


        [Test]
        public async Task GetTodoByIdAsync_RetrievesTodo()
        {
            var todo = new TodoItem
            {
                Id = 1,
                Name = "New Todo",
            };

            repositoryMock.Setup(r => r.GetByIdAsync<TodoItem>(todo.Id))
                .ReturnsAsync(todo);

            var result = await todoService.GetTodoByIdAsync(todo.Id);

            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(todo));
        }

        [Test]
        public async Task GetTodoList_RetrievesTodoList()
        {
            string creatorId = "1";
            var todoList = new TodoList { Id = 1, CreatorId = "1" };

            repositoryMock.Setup(r => r.All<TodoList>())
                .Returns(new List<TodoList>() { todoList }.AsQueryable().BuildMockDbSet().Object);

            var result = await todoService.GetTodoListAsync(creatorId);

            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(todoList));
        }

        [Test]
        public async Task AddTodoAsync_CreatesTodoListIfNotExists()
        {
            string userId = "1";
            string todoName = "New Todo";

            repositoryMock.Setup(r => r.All<TodoList>())
                .Returns(new List<TodoList>().AsQueryable().BuildMockDbSet().Object);

            await todoService.AddTodoAsync(todoName, userId);

            repositoryMock.Verify(r => r.AddAsync(It.Is<TodoList>(
                t => t.CreatorId == userId && t.TodoItems.Count == 1 && t.TodoItems.First().Name == todoName)), Times.Once);
            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task AddTodoAsync_AddsNewTodoToExistingTodoList()
        {
            string userId = "1";
            string todoName = "New Todo";
            var todoList = new TodoList { Id = 1, CreatorId = userId };

            repositoryMock.Setup(r => r.All<TodoList>())
                .Returns(new List<TodoList>() { todoList }.AsQueryable().BuildMockDbSet().Object);

            await todoService.AddTodoAsync(todoName, userId);

            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task AllTodosAsync_RetrievesAllTodos()
        {
            string userId = "1";
            var todoItem = new TodoItem { Id = 1, Name = "New Todo", TodoListId = 1 };
            var todoList = new TodoList { Id = 1, CreatorId = userId, TodoItems = new List<TodoItem>() { todoItem } };
            var todoViewModel = new TodoViewModel() { Todos = new List<TodoItemViewModel>() { new TodoItemViewModel { Id = todoItem.Id, Name = todoItem.Name } } };

            repositoryMock.Setup(r => r.AllReadOnly<TodoList>())
                .Returns(new List<TodoList>() { todoList }.AsQueryable().BuildMockDbSet().Object);
            mapperMock.Setup(m => m.Map<TodoViewModel>(todoList))
                .Returns(todoViewModel);

            var entry = await todoService.AllTodosAsync(userId);

            Assert.IsNotNull(entry);
            Assert.That(entry, Is.EqualTo(todoViewModel));
        }

        [Test]
        public async Task CompleteTodoAsync_SetTaskToCompleted()
        {
            var todo = new TodoItem
            {
                Id = 1,
                Name = "New Todo",
                IsCompleted = false
            };

            repositoryMock.Setup(r => r.GetByIdAsync<TodoItem>(todo.Id))
                .ReturnsAsync(todo);

            await todoService.CompleteTodoAsync(todo.Id);

            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
            Assert.IsTrue(todo.IsCompleted);
        }

        [Test]
        public async Task UncompleteTodoAsync_SetTaskToUncompleted()
        {
            var todo = new TodoItem
            {
                Id = 1,
                Name = "New Todo",
                IsCompleted = true
            };

            repositoryMock.Setup(r => r.GetByIdAsync<TodoItem>(todo.Id))
                .ReturnsAsync(todo);

            await todoService.UncompleteTodoAsync(todo.Id);

            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
            Assert.IsFalse(todo.IsCompleted);
        }

        [Test]
        public async Task DeleteTodoAsync_RemovesTodoItemFromList()
        {
            var todo = new TodoItem
            {
                Id = 1,
                Name = "New Todo",
            };

            repositoryMock.Setup(r => r.GetByIdAsync<TodoItem>(todo.Id))
                .ReturnsAsync(todo);

            await todoService.DeleteTodoAsync(todo.Id);

            repositoryMock.Verify(r => r.RemoveAsync(todo), Times.Once);
            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteAllTodosAsync_RemovesAllTodoItemsFromList()
        {
            string userId = "1";

            var todoItems = new List<TodoItem>
            {
                new TodoItem
                {
                    Id = 1,
                    Name = "New Todo",
                    TodoListId = 1
                },
                new TodoItem
                {
                    Id = 2,
                    Name = "New Todo 2",
                    TodoListId = 1
                }
            };
            var todoList = new TodoList
            {
                Id = 1,
                CreatorId = userId,
                TodoItems = todoItems
            };

            repositoryMock.Setup(r => r.All<TodoList>())
                .Returns(new List<TodoList>(){ todoList }.AsQueryable().BuildMockDbSet().Object);

            await todoService.DeleteAllTodosAsync(userId);

            repositoryMock.Verify(r => r.RemoveRangeAsync(It.IsAny<List<TodoItem>>()), Times.Once);
            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
    }
}
