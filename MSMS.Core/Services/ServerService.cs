using System.Diagnostics;
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
                .AllReadOnly<Server>()
                .Include(s => s.Owner)
                .ToListAsync();

            var mappedModel = _mapper.Map<IEnumerable<ServerViewModel>>(servers);
            return mappedModel;
        }

        public async Task CreateLocationAsync(ServerLocationFormModel model, string creatorId)
        {
            Location location = _mapper.Map<Location>(model); 
            location.CreatorId = creatorId;

            await _repository.AddAsync(location);
            await _repository.SaveChangesAsync();
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

		public async Task<ServerDetailsViewModel> GetServerDetailsAsync(int serverId)
		{
            var server = await _repository.GetByIdAsync<Server>(serverId);

            if (server == null)
            {
                throw new InvalidOperationException($"No server found by id: {serverId}");
            }

            await _repository.LoadReferenceAsync(server, s => s.Owner);
            await _repository.LoadCollectionAsync(server, s => s.Worlds);

            var mappedModel = _mapper.Map<ServerDetailsViewModel>(server);
            return mappedModel;
		}

        public async Task<ServerWorldViewModel> GetServerWorldAsync(int serverId, WorldType worldType)
        {
            var server = await _repository.GetByIdAsync<Server>(serverId);

            if (server == null)
            {
                throw new InvalidOperationException($"No server found by id: {serverId}");
            }

            await _repository.LoadReferenceAsync(server, s => s.Owner);
            await _repository.LoadCollectionAsync(server, s => s.Worlds);

            var world = server.Worlds.FirstOrDefault(w => w.WorldType == worldType);

            if (world == null)
            {
                throw new InvalidOperationException($"Could not find server world with world type: {worldType}");
            }

            await _repository.LoadCollectionAsync(world, w => w.Locations);

            var mappedModel = _mapper.Map<ServerWorldViewModel>(server);
            _mapper.Map(world, mappedModel);
            return mappedModel;
        }

        public async Task<int> GetWorldIdAsync(int serverId, WorldType worldType)
        {
            Server? server = await _repository.GetByIdAsync<Server>(serverId);

            if (server == null)
            {
                throw new InvalidOperationException($"No server found by id: {serverId}");
            }

            await _repository.LoadCollectionAsync(server, s => s.Worlds);

            var world = server.Worlds.FirstOrDefault(w => w.WorldType == worldType);

            if (world == null)
            {
                throw new InvalidOperationException($"Could not find server world with world type: {worldType}");
            }

            return world.Id;
        }

        public async Task<bool> IpExistsAsync(string ip)
        {
            return await _repository
                .AllReadOnly<Server>()
                .AnyAsync(s => s.IpAddress == ip);
        }
    }
}
