using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MSMS.Core.Contracts;
using MSMS.Infrastructure.Data.Enums;
using MSMS.Infrastructure.Data.Models;

namespace MSMS.Web.Controllers
{
    public class ManagerController : BaseController
    {
        private IServerService _serverService;

        public ManagerController(IServerService serverService)
        {
            _serverService = serverService;
        }

        [Authorize(Roles = nameof(Role.Owner))]
        public async Task<ActionResult> Servers()
        {
            return View();
        }

    }
}
