using Microsoft.AspNetCore.Identity;
using MSMS.Infrastructure.Data.Enums;
using MSMS.Infrastructure.Data.Models;

namespace MSMS.Infrastructure.Data.Seeder
{
    public class DbSeeder
    {
        public ApplicationUser GuestUser { get; set; } = null!;
        public ApplicationUser CreatorUser { get; set; } = null!; 
        public Server CreatorServer { get; set; } = null!;
        public World CreatorOverworld { get; set; } = null!;
        public World CreatorNether { get; set; } = null!;
        public World CreatorEnd { get; set; } = null!;
        public Location CreatorOverworldLocation { get; set; } = null!;
        public Location CreatorNetherLocation { get; set; } = null!;
        public Location CreatorEndLocation { get; set; } = null!;

        public DbSeeder()
        {
            SeedDb();
        }

        private void SeedDb()
        {
            SeedUsers();
            SeedServers();
            SeedWorlds();
            SeedLocations();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            GuestUser = new ApplicationUser
            {
                Id = "091a0932-5bea-4155-9ad1-db73e28aa455",
                UserName = "guest",
                NormalizedUserName = "GUEST",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM",
                FirstName = "Madman",
                LastName = "Waller"
            };

            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "guest123");

            CreatorUser = new ApplicationUser
            {
                Id = "13c6c731-7d69-4db3-a3c8-1d0b77f2d26a",
                UserName = "creator",
                NormalizedUserName = "CREATOR",
                Email = "creator@mail.com",
                NormalizedEmail = "CREATOR@MAIL.COM",
                FirstName = "Willson",
                LastName = "Smith"
            };

            CreatorUser.PasswordHash = hasher.HashPassword(CreatorUser, "creator123");
        }

        private void SeedServers()
        {
            CreatorServer = new Server
            {
                Id = 1,
                Name = "My Server",
                ImagePath = "/images/server-banners/default.jpeg",
                IpAddress = "myserver.mcserver.com",
                GameVersion = "1.20.2",
                PlayMode = PlayMode.Survival,
                Description = "This is my first created server!",
                OwnerId = "13c6c731-7d69-4db3-a3c8-1d0b77f2d26a",
            };
        }

        private void SeedWorlds()
        {
            CreatorOverworld = new World(WorldType.Overworld)
            {
                Id = 1,
                Seed = null,
                ServerId = 1,
            };

            CreatorNether = new World (WorldType.Nether)
            {
                Id = 2,
                Seed = null,
                ServerId = 1,
            };

            CreatorEnd = new World(WorldType.End)
            {
                Id = 3,
                Seed = null,
                ServerId = 1,
            };
        }

        private void SeedLocations()
        {
            CreatorOverworldLocation = new Location
            {
                Id = 1,
                Name = "My Overworld Location",
                Coordinates = "0/0/0",
                LocationType = LocationType.Home,
                AccessModifier = LocationAccessModifier.Public,
                Description = "My first home",
                CreatorId = "13c6c731-7d69-4db3-a3c8-1d0b77f2d26a",
                WorldId = 1
            };
             
             CreatorNetherLocation = new Location
            {
                Id = 2,
                Name = "My Nether Location",
                Coordinates = "250/250/250",
                LocationType = LocationType.Portal,
                AccessModifier = LocationAccessModifier.Private,
                Description = "Portal to home",
                CreatorId = "13c6c731-7d69-4db3-a3c8-1d0b77f2d26a",
                WorldId = 2
            };

            CreatorEndLocation = new Location
            {
                Id = 3,
                Name = "My End Location",
                Coordinates = "-100/-100/-100",
                LocationType = LocationType.Farm,
                AccessModifier = LocationAccessModifier.Public,
                Description = "Enderman farm",
                CreatorId = "13c6c731-7d69-4db3-a3c8-1d0b77f2d26a",
                WorldId = 3
            };
        }
    }
}
