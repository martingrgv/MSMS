using AutoMapper;
using MSMS.Core.Contracts;
using MSMS.Core.Models;
using MSMS.Infrastructure.Common;
using MSMS.Infrastructure.Data;
using MSMS.Infrastructure.Data.Enums;
using MSMS.Infrastructure.Data.Models;

namespace MSMS.Core.Services
{
    public class ServerService : IServerService
    {
        private IRepository _repository;
        private IMapper _mapper;

        public ServerService(IRepository repository, IMapper mapper)
        {
            _repository = repository;           
            _mapper = mapper;
        }

        public IEnumerable<ServerViewModel> AllServers()
        {
            return new List<ServerViewModel>();
        }

        public void CreateServer(ServerFormModel model, string serverImagePath, string ownerId)
        {
            Server entity = _mapper.Map<Server>(model);
            entity.ImagePath = serverImagePath;
            entity.OwnerId = ownerId;
            entity.Worlds =
            [
                new World(WorldType.Overworld),
                new World(WorldType.Nether),
                new World(WorldType.End) 
            ];

            _repository.Add(entity);
            _repository.SaveChanges();
        }
    }
}
