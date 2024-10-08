using MSMS.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSMS.Infrastructure.Data.Models
{
    public class World
    {
        public World(WorldType worldType)
        {
            if (worldType == WorldType.Overworld) ImagePath = "/images/world/overworld.jpg";
            else if (worldType == WorldType.Nether) ImagePath = "/images/world/nether.jpg";
            else if (worldType == WorldType.End) ImagePath = "/images/world/end.jpg";
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
