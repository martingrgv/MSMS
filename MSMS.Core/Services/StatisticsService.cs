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

    public Task<int> RegisteredUsersCountAsync()
    {
        int count = _repository.AllReadOnly<ApplicationUser>().Count();
        return Task.FromResult(count);
    }

    public Task<int> ServersCountAsync()
    {
        int count = _repository.AllReadOnly<Server>().Count();
        return Task.FromResult(count);
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
