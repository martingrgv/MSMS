using MSMS.Infrastructure.Data.Enums;

namespace MSMS.Infrastructure.Data.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Coordinates { get; set; } = null!;
        public LocationType LocationType { get; set; }
        public LocationAccessModifier AccessModifier { get; set; }
        public string? Description { get; set; }

        public string CreatorId { get; set; } = null!;
        public ApplicationUser Creator { get; set; } = null!;

        public int WorldId { get; set; }
        public World World { get; set; } = null!;
    }
}
