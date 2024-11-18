using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MSMS.Core.Contracts;
using MSMS.Core.Models;
using MSMS.Infrastructure.Data.Enums;
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
        public async Task<IActionResult> All()
        {
            var models = await _serverService.AllServersAsync();
            return View(models);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Server/Details/{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var model = await _serverService.GetServerDetailsAsync(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ServerFormModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServerFormModel model, IFormFile? serverImage)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(nameof(model.IpAddress), "Invalid server data.");
                return View();
            }

            if (await _serverService.IpExistsAsync(model.IpAddress))
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

            await _serverService.CreateServerAsync(model, imagePath, User.Id());
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        [Route("Server/{id}/{worldType}")]
        public async Task<IActionResult> World([FromRoute] int id, string worldType)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            if (!Enum.TryParse<WorldType>(worldType, true, out var parsedType))
            {
                return BadRequest();               
            }

            var model = await _serverService.GetServerWorldAsync(id, parsedType);

            return View(model);
        }

        [HttpGet]
        [Route("Server/{id}/{worldType}/AddLocation")]
        public IActionResult AddLocation(int id, WorldType worldType)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var model = new ServerLocationFormModel
            {
                WorldType = worldType,
                CreatorId = User.Id()
            };
            return View(model);
        }

        [HttpPost]
        [Route("Server/{id}/{worldType}/AddLocation")]
        public IActionResult AddLocation (ServerLocationFormModel model)
        {
            model.WorldId = 1;

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            return RedirectToAction(nameof(World), new { id = model.WorldId, worldType = model.WorldType.ToString() });
        }
    }
}
