using MSMS.Infrastructure.Data.Enums;
using MSMS.Infrastructure.Data.Models;

namespace MSMS.Core.Models;

public class ServerWorldViewModel
{
        public int Id { get; set; }
        public int ServerId { get; set; }
        public string ServerName { get; set; } = null!;
        public string ImagePath { get; set; } = null!;
        public string IpAddress { get; set; } = null!;
        public string GameVersion { get; set; } = null!;
        public PlayMode PlayMode { get; set; }
        public string? Description { get; set; } = null!;
        public string OwnerName { get; set; } = null!;
        public WorldType WorldType { get; set; } 
        public ICollection<Location> Locations {get; set;} = new HashSet<Location>();
}
