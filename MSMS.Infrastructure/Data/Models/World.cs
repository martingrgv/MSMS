using MSMS.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSMS.Infrastructure.Data.Models
{
    public class World
    {
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
