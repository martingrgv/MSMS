using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSMS.Core.Contracts;
using MSMS.Infrastructure.Data.Enums;
using MSMS.Web.Controllers;

namespace MSMS.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = nameof(Role.Owner))]
    public class PanelController : BaseController
    {
        private IServerService _serverService;

        public PanelController(IServerService serverService)
        {
            _serverService = serverService;
        }

        [HttpGet]
        public async Task<ActionResult> Controls()
        {
            return View();
        }

    }
}
