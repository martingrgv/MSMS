using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MSMS.Core.Contracts;
using MSMS.Core.Models;

namespace MSMS.Web.Controllers
{
    public class TodoController : BaseController
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("/Todo")]
        public async Task<IActionResult> Mine()
        {
            var model = await _todoService.AllTodosAsync(User.Id());
            return View(model);
        }

        [HttpPost("/Todo/Add")]
        public async Task<IActionResult> Add([FromForm]TodoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Mine));
            }

            await _todoService.AddTodoAsync(model.TodoCreateModel.Name, User.Id());
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost("/Todo/Complete")]
        public async Task<IActionResult> Complete([FromForm]int id)
        {
            await _todoService.CompleteTodoAsync(id);
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost("/Todo/Uncomplete")]
        public async Task<IActionResult> Uncomplete([FromForm]int id)
        {
            await _todoService.UncompleteTodoAsync(id);
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost("/Todo/Delete")]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            await _todoService.DeleteTodoAsync(id);
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost("/Todo/DeleteCompleted")]
        public async Task<IActionResult> DeleteCompleted()
        {
            await _todoService.DeleteAllTodosAsync(User.Id());
            return RedirectToAction(nameof(Mine));
        }
    }
}
