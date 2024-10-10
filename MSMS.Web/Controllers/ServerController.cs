using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSMS.Core.Contracts;
using MSMS.Core.Models;
using System.Security.Claims;

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
            var models = _serverService.AllServers();
            return View(models);
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
            return View(new ServerFormModel());
        }

        [HttpPost]
        public IActionResult Create(ServerFormModel model, IFormFile? serverImage)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(nameof(model.IpAddress), "Invalid server data.");
                return View();
            }

            if (_serverService.ExistsByIp(model.IpAddress))
            {
                ModelState.AddModelError(nameof(model.IpAddress), "Server with this IP address already exists.");
                return View();
            }

            var imagePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "images",
                "server-banners",
                "default.jpeg");

            if (serverImage != null && serverImage.Length > 0)
            {
                imagePath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    "server-banners",
                    Guid.NewGuid().ToString() + Path.GetExtension(serverImage.FileName));

                using (var stream = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
                    serverImage.CopyTo(stream);
            }

            _serverService.CreateServer(model, imagePath, User.Id());

            return RedirectToAction(nameof(All));
        }
    }
}
