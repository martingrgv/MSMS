using MSMS.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSMS.Infrastructure.Data.Models
{
    public class World
    {
        private const string OVERWORLD_IMAGE_PATH = "/images/servers/default/overworld.jpg";
        private const string NETHER_IMAGE_PATH = "/images/servers/default/nether.jpg";
        private const string END_IMAGE_PATH = "/images/servers/default/end.jpg";

        public World(WorldType worldType)
        {
            if (worldType == WorldType.Overworld) ImagePath = OVERWORLD_IMAGE_PATH;
            else if (worldType == WorldType.Nether) ImagePath = NETHER_IMAGE_PATH;
            else if (worldType == WorldType.End) ImagePath = END_IMAGE_PATH;
            else throw new ArgumentException("Invalid world type!");

            WorldType = worldType;
        }

        [Key]
        public int Id { get; set; }

        public string ImagePath { get; set; } = null!;

        public string? Seed { get; set; } = null!;

        [Required]
        public WorldType WorldType { get; set; }

        [Required]
        public int ServerId { get; set; }

        [ForeignKey(nameof(ServerId))]
        public Server Server { get; set; } = null!;

        public ICollection<Location> Locations { get; set; } = new List<Location>();
    }
}
