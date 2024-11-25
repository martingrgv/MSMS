using System;
using Microsoft.EntityFrameworkCore;
using MSMS.Core.Contracts;
using MSMS.Infrastructure.Common;
using MSMS.Infrastructure.Data.Models;

namespace MSMS.Core.Services;

public class StatisticsService : IStatisticsService
{
    private readonly IRepository _repository;

    public StatisticsService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> RegisteredUsersCountAsync()
    {
        return await _repository.AllReadOnly<ApplicationUser>().CountAsync();
    }

    public async Task<int> ServersCountAsync()
    {
        return await _repository.AllReadOnly<Server>().CountAsync();
    }

    public async Task<int> UserServersCountAsync(string userId)
    {
        return await _repository.AllReadOnly<Server>().Where(s => s.OwnerId == userId).CountAsync();
    }

    public async Task<int> UserServersUsersCountAsync(string userId)
    {
        throw new NotImplementedException();
    }
}
