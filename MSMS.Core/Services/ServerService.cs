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
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ServerService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AllServersQueryModel> AllServersAsync(string? ownerId = null, string? searchItem = null, SortingType sortingType = SortingType.Newest, int currentPage = 1, int serversPerPage = 9)
        {
            IQueryable<Server> servers = _repository.AllReadOnly<Server>().Include(s => s.Owner);

            if (ownerId != null)
            {
                servers = _repository.AllReadOnly<Server>().Where(s => s.OwnerId == ownerId).Include(s => s.Owner);
            }

            if (searchItem != null)
            {
                string normalizedSearch = searchItem.ToUpper();
                servers = servers
                    .Where(s => s.Name.ToUpper().Contains(searchItem) ||
                        s.Owner.UserName!.ToUpper().Contains(searchItem));
            }

            servers = sortingType switch
            {
                SortingType.Oldest => servers.OrderBy(s => s.Id),
                _ => servers.OrderByDescending(s => s.Id)
            };

            var serversToReturn = await servers
                .Skip((currentPage - 1) * serversPerPage)
                .Take(serversPerPage)
                .Select(s => new ServerViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    ImagePath = s.ImagePath.Replace(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), ""),
                    IpAddress = s.IpAddress,
                    GameVersion = s.GameVersion,
                    PlayMode = s.PlayMode,
                    Description = s.Description,
                    OwnerName = s.Owner.UserName!
                })
                .ToListAsync();

            return new AllServersQueryModel
            {
                TotalServersCount = servers.Count(),
                Servers = serversToReturn
            };
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
            Server server = _mapper.Map<Server>(model);
            server.ImagePath = serverImagePath;
            server.OwnerId = ownerId;
            server.Worlds = CreateWorlds();

            await _repository.AddAsync(server);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteServer(int serverId)
        {
            var server = await _repository.GetByIdAsync<Server>(serverId);
            if (server != null)
            {
                await _repository.RemoveAsync(server);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task DeleteUserServersAsync(string userId)
        {
            var servers = await _repository.All<Server>().Where(s => s.OwnerId == userId).ToListAsync();
            await _repository.RemoveRangeAsync(servers);
            await _repository.SaveChangesAsync();
        }

        public async Task EditServer(ServerEditModel model)
        {
            var server = await _repository.All<Server>().FirstOrDefaultAsync(s => s.Id == model.Id);
            if (server == null)
            {
                return;
            }

            _mapper.Map(model, server);
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

        public async Task<bool> ServerHasOwner(int serverId, string ownerId)
        {
            return await _repository.AllReadOnly<Server>().FirstOrDefaultAsync(s => s.Id == serverId && s.OwnerId == ownerId) != null;
        }

        private static World[] CreateWorlds()
            => [
                new World(WorldType.Overworld),
                new World(WorldType.Nether),
                new World(WorldType.End)
            ];
    }
}
