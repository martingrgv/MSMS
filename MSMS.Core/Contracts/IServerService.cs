using MSMS.Core.Models;

namespace MSMS.Core.Contracts
{
    public interface IServerService
    {
        public IEnumerable<ServerViewModel> AllServers();
        public void CreateServer(ServerFormModel model, string serverImagePath, string ownerId);
    }
}
