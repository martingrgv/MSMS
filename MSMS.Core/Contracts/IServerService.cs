using MSMS.Core.Models;
using MSMS.Infrastructure.Data.Enums;

namespace MSMS.Core.Contracts
{
    public interface IServerService
    {
        Task<IEnumerable<ServerViewModel>> AllServersAsync();
        Task CreateServerAsync(ServerFormModel model, string serverImagePath, string ownerId);
        Task<bool> IpExistsAsync(string ip);
        Task<ServerDetailsViewModel> GetServerDetailsAsync(int serverId);
        Task<ServerWorldViewModel> GetServerWorldAsync(int serverId, WorldType worldType);
        Task<int> GetWorldIdAsync(int serverId, WorldType worldType);
        Task CreateLocationAsync(ServerLocationFormModel model, string creatorId);
        Task<int> ServersCountAsync();
    }
}
