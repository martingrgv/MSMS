using MSMS.Infrastructure.Data.Enums;

namespace MSMS.Infrastructure.Data.Models
{
    public class Server
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImagePath { get; set; } = null!;
        public string IpAddress { get; set; } = null!;
        public string GameVersion { get; set; } = null!;
        public PlayMode PlayMode { get; set; }
        public string? Description { get; set; } = null!;

        public string OwnerId { get; set; } = null!;
        public ApplicationUser Owner { get; set; } = null!;

        public ICollection<World> Worlds { get; set; } = [];
    }
}
