using MSMS.Infrastructure.Data.Enums;

namespace MSMS.Core.Models
{
    public class ServerViewModel
    {
        public string Name { get; set; } = null!;
        public string ImagePath { get; set; } = null!;
        public string IpAddress { get; set; } = null!;
        public string GameVersion { get; set; } = null!;
        public PlayMode PlayMode { get; set; }
        public string? Description { get; set; } = null!;
        public string OwnerName { get; set; } = null!;
    }
}
