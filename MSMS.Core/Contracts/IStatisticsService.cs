using System;

namespace MSMS.Core.Contracts;

public interface IStatisticsService
{
    Task<int> ServersCountAsync();
    Task<int> RegisteredUsersCountAsync();
    Task<int> UserServersCountAsync(string userId);
    Task<int> UserServersUsersCountAsync(string userId);
}
