using MSMS.Infrastructure.Data.Enums;

namespace MSMS.Infrastructure.Data.Models
{
    public class World
    {
        private readonly Dictionary<WorldType, string> _typeImageLocations = new()
        {
            { WorldType.Overworld, "/images/servers/default/overworld.jpg" },
            { WorldType.Nether, "/images/servers/default/nether.jpg" },
            { WorldType.End, "/images/servers/default/end.jpg" },
        };

        private World()
        {
            // For EFCore
        }

        public World(WorldType worldType)
        {
            if (!_typeImageLocations.TryGetValue(worldType, out var imagePath))
            {
                throw new ArgumentException("Invalid world type!");
            }

            WorldType = worldType;
            ImagePath = imagePath;
        }

        public int Id { get; set; }
        public string ImagePath { get; set; } = null!;
        public string? Seed { get; set; } = null!;
        public WorldType WorldType { get; set; }

        public int ServerId { get; set; }
        public Server Server { get; set; } = null!;

        public ICollection<Location> Locations { get; set; } = [];
    }
}
