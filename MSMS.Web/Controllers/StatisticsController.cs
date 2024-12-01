using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSMS.Core.Contracts;

namespace MSMS.Web.Controllers;

[ApiController]
[AllowAnonymous]
public class StatisticsController : BaseController
{
    private readonly IStatisticsService _statisticsService;
    
    public StatisticsController(IStatisticsService statisticsService )
    {
        _statisticsService = statisticsService;
    }

    [HttpGet("/api/statistics/totalServersCount")]
    public async Task<ActionResult<int>> TotalServersCount()
    {
       return await _statisticsService.ServersCountAsync();
    }

    [HttpGet("/api/statistics/registeredUsersCount")]
    public async Task<ActionResult<int>> RegisteredUsersCount()
    {
        return await _statisticsService.RegisteredUsersCountAsync();
    }

    [HttpGet("/api/statistics/serversCount")]
    public async Task<ActionResult<int>> UserServersCount()
    {
        return await _statisticsService.UserServersCountAsync(User.Id());
    }

    [HttpGet("/api/statistics/serverUsersCount")]
    public async Task<ActionResult<int>> UserServersUsersCount()
    {
        return await _statisticsService.UserServersUsersCountAsync(User.Id());
    }
}
