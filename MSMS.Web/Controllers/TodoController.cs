using Microsoft.AspNetCore.Mvc;
using MSMS.Core.Models;

namespace MSMS.Web.Controllers
{
    public class TodoController : BaseController
    {
        [HttpGet("/Todo")]
        public IActionResult Mine()
        {
            var model = new List<TodoItemViewModel>{
                new TodoItemViewModel { Name = "Finish The Website"},
                new TodoItemViewModel { Name = "Unit Tests", isCompleted = true }
            };

            return View(model);
        }

        [HttpPost("/Todo/Add")]
        public IActionResult Add()
        {
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost("/Todo/Complete")]
        public IActionResult Complete()
        {
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost("/Todo/Delete")]
        public IActionResult DeleteCompleted()
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
