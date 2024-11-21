using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
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
}
