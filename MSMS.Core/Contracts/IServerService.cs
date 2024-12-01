using MSMS.Core.Models;
using MSMS.Infrastructure.Data.Enums;

namespace MSMS.Core.Contracts
{
    public interface IServerService
    {
        Task<AllServersQueryModel> AllServersAsync(string? ownerId = null, string? searchItem = null, SortingType sortingType = SortingType.Newest, int currentPage = 1, int serversPerPage = 9);
        Task CreateServerAsync(ServerFormModel model, string serverImagePath, string ownerId);
        Task<bool> IpExistsAsync(string ip);
        Task<ServerDetailsViewModel> GetServerDetailsAsync(int serverId);
        Task<ServerWorldViewModel> GetServerWorldAsync(int serverId, WorldType worldType);
        Task<int> GetWorldIdAsync(int serverId, WorldType worldType);
        Task CreateLocationAsync(ServerLocationFormModel model, string creatorId);
        Task EditServer (ServerEditModel model);
        Task DeleteServer(int serverId);
        Task DeleteUserServersAsync(string userId);
        Task<bool> ServerHasOwner(int serverId, string ownerId);
    }
}
