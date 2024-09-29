using Microsoft.AspNetCore.Mvc;

namespace MSMS.Web.Controllers
{
    public class ServerController : Controller
    {
        [HttpGet]
        public IActionResult All()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
