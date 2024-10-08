using System;
using MSMS.Core.Models;

namespace MSMS.Core.Contracts
{
    public interface IServerService
    {
        public void CreateServer(ServerFormModel model);
    }
}
