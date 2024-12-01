using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSMS.Core.Contracts;
using MSMS.Core.Models;
using MSMS.Infrastructure.Data.Enums;
using MSMS.Web.Controllers;

namespace MSMS.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = nameof(Role.Owner))]
    public class PanelController : BaseController
    {
        private readonly IServerService _serverService;
        private readonly IStatisticsService _statisticsService;
        private readonly IMapper _mapper; 

        public PanelController(IServerService serverService, IStatisticsService statisticsService, IMapper mapper)
        {
            _serverService = serverService;
            _statisticsService = statisticsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Controls()
        {
            var serversCount = await _statisticsService.UserServersCountAsync(User.Id());
            var usersCount = await _statisticsService.RegisteredUsersCountAsync();

            return View(new ManagerPanelStatisticsViewModel
            {
                ServersCount = serversCount,
                TotalServersUsersCount = usersCount
            });
        }

        [HttpGet]
        public async Task<IActionResult> Servers([FromQuery]AllServersQueryModel query)
        {
            var model = await _serverService.AllServersAsync(
                User.Id(),
                query.SearchItem,
                query.SortingType,
                query.CurrentPage,
                AllServersQueryModel.ServersPerPage
            );
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var server = await _serverService.GetServerDetailsAsync(id);

            if (server == null)
            {
                return BadRequest();
            }

            var model = _mapper.Map<ServerEditModel>(server);
            model.Id = id;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] ServerEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _serverService.EditServer(model);
            return RedirectToAction(nameof(Servers));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            await _serverService.DeleteServer(id);
            return RedirectToAction(nameof(Servers));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUserServers()
        {
            await _serverService.DeleteUserServersAsync(User.Id());
            return RedirectToAction(nameof(Controls));
        }
    }
}
