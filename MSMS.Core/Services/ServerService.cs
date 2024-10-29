using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MSMS.Core.Contracts;
using MSMS.Core.Models;
using MSMS.Infrastructure.Common;
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

        public async Task<IEnumerable<ServerViewModel>> AllServersAsync()
        {
            var servers = await _repository
                .All<Server>()
                .Include(s => s.Worlds)
                .Include(s => s.Owner)
                .ToListAsync();

            var mappedModel = _mapper.Map<IEnumerable<ServerViewModel>>(servers);
            return mappedModel;
        }

        public async Task CreateServerAsync(ServerFormModel model, string serverImagePath, string ownerId)
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

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task<bool> IpExistsAsync(string ip)
        {
            return await _repository
                .AllReadOnly<Server>()
                .AnyAsync(s => s.IpAddress == ip);
        }
    }
}
