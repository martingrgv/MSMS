using MSMS.Core.Models;

namespace MSMS.Core.Contracts
{
    public interface IServerService
    {
        public Task<IEnumerable<ServerViewModel>> AllServersAsync();
        public Task CreateServerAsync(ServerFormModel model, string serverImagePath, string ownerId);
        public Task<bool> IpExistsAsync(string ip);
    }
}
