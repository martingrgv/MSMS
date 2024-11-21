using Microsoft.AspNetCore.Mvc;
using MSMS.Web.Models;
using System.Diagnostics;

namespace MSMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Home/Error401")]
        public IActionResult Error401()
        {
            Response.StatusCode = 401;
            return View("Error401");
        }

        [Route("Home/Error404")]
        public IActionResult Error404()
        {
            Response.StatusCode = 404;
            return View("Error404");
        }

        [Route("Home/Error500")]
        public IActionResult Error500()
        {
            Response.StatusCode = 500;
            return View("Error500");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
