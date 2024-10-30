using Microsoft.AspNetCore.Identity;
using MSMS.Infrastructure.Data.Enums;
using MSMS.Infrastructure.Data.Models;

namespace MSMS.Infrastructure.Data.Seeder
{
    public static class DbSeeder
    {
        public static ApplicationUser[] SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            var guestUser = new ApplicationUser
            {
                Id = "091a0932-5bea-4155-9ad1-db73e28aa455",
                UserName = "guest",
                NormalizedUserName = "GUEST",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM",
                FirstName = "Madman",
                LastName = "Waller"
            };
            var serverCreator = new ApplicationUser
            {
                Id = "13c6c731-7d69-4db3-a3c8-1d0b77f2d26a",
                UserName = "creator",
                NormalizedUserName = "CREATOR",
                Email = "creator@mail.com",
                NormalizedEmail = "CREATOR@MAIL.COM",
                FirstName = "Willson",
                LastName = "Smith"
            };

            guestUser.PasswordHash = hasher.HashPassword(guestUser, "guest123");
            serverCreator.PasswordHash = hasher.HashPassword(serverCreator, "creator123");

            return new [] { guestUser, serverCreator };
        }

        public static Server[] SeedServers()
        {
            var creatorServer = new Server
            {
                Id = 1,
                Name = "My Server",
                ImagePath = "/images/server-banners/default.jpeg",
                IpAddress = "myserver.mcserver.com",
                GameVersion = "1.20.2",
                PlayMode = PlayMode.Survival,
                Description = "This is my first created server!",
                OwnerId = "13c6c731-7d69-4db3-a3c8-1d0b77f2d26a",
                Worlds =
                {
                }
            };

            return new [] { creatorServer };
        }

        public static World[] SeedWorlds()
        {
            var overworld = new World(WorldType.Overworld)
            {
                Id = 1,
                Seed = null,
                ServerId = 1,
                Locations = 
                {
                }
            };

            var nether = new World (WorldType.Nether)
            {
                Id = 2,
                Seed = null,
                ServerId = 1,
                Locations = 
                {
                }
            };

            var end = new World(WorldType.End)
            {
                Id = 3,
                Seed = null,
                ServerId = 1,
            };

            return new [] { overworld, nether, end };
        }

        public static Location[] SeedLocations()
        {
            var overworld = new Location
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
             
             var nether = new Location
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

            var end = new Location
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

            return new [] { overworld, nether, end };
        }
    }
}
