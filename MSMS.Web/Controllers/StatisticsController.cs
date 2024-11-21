using System;
using Microsoft.AspNetCore.Mvc;
using MSMS.Core.Contracts;

namespace MSMS.Web.Controllers;

[ApiController]
public class StatisticsController
{
    private readonly IServerService _serverService;
    
    public StatisticsController(IServerService serverService)
    {
        _serverService = serverService;
    }

    [HttpGet("/api/server/totalServersCount")]
    public async Task<ActionResult<int>> TotalServersCount()
    {
       return await _serverService.ServersCountAsync();
    }
}
