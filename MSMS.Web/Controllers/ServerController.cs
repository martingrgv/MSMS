using Microsoft.AspNetCore.Mvc;

namespace MSMS.Web.Controllers
{
    public class ServerController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
