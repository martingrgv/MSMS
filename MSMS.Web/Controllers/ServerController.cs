using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSMS.Core.Contracts;
using MSMS.Core.Models;

namespace MSMS.Web.Controllers
{
    public class ServerController : BaseController
    {
        private IServerService _serverService;

        public ServerController(IServerService serverService)
        {
            _serverService = serverService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult All()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Details([FromRoute] int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ServerFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _serverService.CreateServer(model);

            return RedirectToAction(nameof(All));
        }
    }
}
