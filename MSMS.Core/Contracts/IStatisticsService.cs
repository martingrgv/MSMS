using System;

namespace MSMS.Core.Contracts;

public interface IStatisticsService
{
    Task<int> ServersCountAsync();
    Task<int> RegisteredUsersCountAsync();
}
