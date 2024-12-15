using Microsoft.EntityFrameworkCore;
using MSMS.Infrastructure.Common;
using MSMS.Infrastructure.Data;
using MSMS.Infrastructure.Data.Models;

namespace MSMS.Tests
{
    public class RepositoryTests
    {
        private DbContextOptions<MSMSDbContext> contextOptions;
        private MSMSDbContext context;
        private IRepository repository;

        [SetUp]
        public void Setup()
        {
            contextOptions = new DbContextOptionsBuilder<MSMSDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            context = new MSMSDbContext(contextOptions);
            repository = new Repository(context);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [Test]
        public async Task AddAsync_AddsEntityToDatabase()
        {
            var entity = new Server
            {
                Id = 1,
                Name = "Server Name",
                IpAddress = "server.address.com",
                GameVersion = "1.1.1",
                ImagePath = "/",
                PlayMode = Infrastructure.Data.Enums.PlayMode.Adventure,
                OwnerId = "1",
            };

            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();

            var result = await context.Set<Server>().FindAsync(1);
            Assert.IsNotNull(result);
            Assert.That(entity.Name, Is.EqualTo(result.Name));
        }

        [Test]
        public async Task AddRangeAsnyc_AddsEntitiesToDatabase()
        {
            var entity = new Server
            {
                Id = 1,
                Name = "Server Name",
                IpAddress = "server.address.com",
                GameVersion = "1.1.1",
                ImagePath = "/",
                PlayMode = Infrastructure.Data.Enums.PlayMode.Adventure,
                OwnerId = "1",
            };
            var entity2 = new Server
            {
                Id = 2,
                Name = "Server Name",
                IpAddress = "server.address.com",
                GameVersion = "1.1.1",
                ImagePath = "/",
                PlayMode = Infrastructure.Data.Enums.PlayMode.Adventure,
                OwnerId = "1",
            };

            var entities = new List<Server> { entity, entity2 };

            await repository.AddRangeAsync(entities);
            await repository.SaveChangesAsync();

            var result = await context.Set<Server>().FindAsync(1);
            var result2 = await context.Set<Server>().FindAsync(2);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result2);
            Assert.That(entity.Name, Is.EqualTo(result.Name));
            Assert.That(entity2.Name, Is.EqualTo(result2.Name));
        }

        [Test]
        public void All_ReturnsAllEntities()
        {
            var entity = new Server
            {
                Id = 1,
                Name = "Server Name",
                IpAddress = "server.address.com",
                GameVersion = "1.1.1",
                ImagePath = "/",
                PlayMode = Infrastructure.Data.Enums.PlayMode.Adventure,
                OwnerId = "1",
            };

            context.Set<Server>().Add(entity);
            context.SaveChanges();

            var entities = repository.All<Server>().ToList();

            Assert.IsNotNull(entities);
            Assert.That(entities.Count, Is.EqualTo(1));
        }

        [Test]
        public void AllReadOnly_ReturnsAllEntities()
        {
            var entity = new Server
            {
                Id = 1,
                Name = "Server Name",
                IpAddress = "server.address.com",
                GameVersion = "1.1.1",
                ImagePath = "/",
                PlayMode = Infrastructure.Data.Enums.PlayMode.Adventure,
                OwnerId = "1",
            };

            context.Set<Server>().Add(entity);
            context.SaveChanges();

            var entities = repository.AllReadOnly<Server>().ToList();

            Assert.IsNotNull(entities);
            Assert.That(entities.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task LoadReferenceAsync_LoadsNavigationProperty()
        {
            var entity = new Server
            {
                Id = 1,
                Name = "Server Name",
                IpAddress = "server.address.com",
                GameVersion = "1.1.1",
                ImagePath = "/",
                PlayMode = Infrastructure.Data.Enums.PlayMode.Adventure,
                OwnerId = "1",
            };
            var user = new ApplicationUser
            {
                Id = "1",
                UserName = "username",
                NormalizedUserName = "USERNAME",
                Email = "username@mail.com",
                NormalizedEmail = "USERNAME@MAIL.COM",
                FirstName = "First",
                LastName = "Last",
                PasswordHash = "123"
            };

            context.Set<Server>().Add(entity);
            context.Set<ApplicationUser>().Add(user);
            context.SaveChanges();

            await repository.LoadReferenceAsync(entity, e => e.Owner);
            Assert.That(entity.Owner.UserName, Is.EqualTo(user.UserName));
        }

        [Test]
        public async Task LoadCollectionAsync_LoadsNavigationProperty()
        {
            var entity = new Server
            {
                Id = 1,
                Name = "Server Name",
                IpAddress = "server.address.com",
                GameVersion = "1.1.1",
                ImagePath = "/",
                PlayMode = Infrastructure.Data.Enums.PlayMode.Adventure,
                OwnerId = "1",
            };
            var world = new World(Infrastructure.Data.Enums.WorldType.Overworld)
            {
                Id = 1,
                ImagePath = "/",
                ServerId = 1,
            };
            var world2 = new World(Infrastructure.Data.Enums.WorldType.Overworld)
            {
                Id = 2,
                ImagePath = "/",
                ServerId = 1,
            };

            var worlds = new List<World> { world, world2 };

            context.Set<Server>().Add(entity);
            context.Set<World>().AddRange(worlds);
            context.SaveChanges();

            await repository.LoadCollectionAsync(entity, e => e.Worlds);
            Assert.That(entity.Worlds.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task GetByIdAsync_ReturnsCorrectlyEntity()
        {
            var entity = new Server
            {
                Id = 1,
                Name = "Server Name",
                IpAddress = "server.address.com",
                GameVersion = "1.1.1",
                ImagePath = "/",
                PlayMode = Infrastructure.Data.Enums.PlayMode.Adventure,
                OwnerId = "1",
            };

            context.Set<Server>().Add(entity);
            context.SaveChanges();

            var result = await repository.GetByIdAsync<Server>(1);
            Assert.IsNotNull(result);
            Assert.That(entity, Is.EqualTo(result));
        }

        [Test]
        public async Task RemoveAsync_RemovedEntityFromDatabase()
        {
            var entity = new Server
            {
                Id = 1,
                Name = "Server Name",
                IpAddress = "server.address.com",
                GameVersion = "1.1.1",
                ImagePath = "/",
                PlayMode = Infrastructure.Data.Enums.PlayMode.Adventure,
                OwnerId = "1",
            };

            context.Set<Server>().Add(entity);
            context.SaveChanges();

            await repository.RemoveAsync(entity);
            await repository.SaveChangesAsync();

            int count = context.Set<Server>().Count();
            Assert.That(count, Is.EqualTo(0));
        }

        [Test]
        public async Task RemoveRangeAsync_RemovedEntitiesFromDatabase()
        {
            var entity = new Server
            {
                Id = 1,
                Name = "Server Name",
                IpAddress = "server.address.com",
                GameVersion = "1.1.1",
                ImagePath = "/",
                PlayMode = Infrastructure.Data.Enums.PlayMode.Adventure,
                OwnerId = "1",
            };
            var entity2 = new Server
            {
                Id = 2,
                Name = "Server Name",
                IpAddress = "server.address.com",
                GameVersion = "1.1.1",
                ImagePath = "/",
                PlayMode = Infrastructure.Data.Enums.PlayMode.Adventure,
                OwnerId = "1",
            };

            var entities = new List<Server> { entity, entity2 };

            context.Set<Server>().AddRange(entities);
            context.SaveChanges();

            await repository.RemoveRangeAsync(entities);
            await repository.SaveChangesAsync();

            int count = context.Set<Server>().Count();
            Assert.That(count, Is.EqualTo(0));
        }
    }
}