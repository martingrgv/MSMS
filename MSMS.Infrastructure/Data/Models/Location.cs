using MSMS.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MSMS.Infrastructure.ValidationConstants;

namespace MSMS.Infrastructure.Data.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(LOCATION_NAME_MAX_LENGTH)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(LOCATION_COORDINATES_MAX_LENGTH)]
        public string Coordinates { get; set; } = null!;

        [Required]
        public LocationType LocationType { get; set; }

        [Required]
        public LocationAccessModifier AccessModifier { get; set; }

        [MaxLength(DESCRIPTION_MAX_LENGTH)]
        public string? Description { get; set; }

        [Required]
        public string CreatorId { get; set; } = null!;

        [ForeignKey(nameof(CreatorId))]
        public ApplicationUser Creator { get; set; } = null!;

        public int? WorldId { get; set; }

        [ForeignKey(nameof(WorldId))]
        public World World { get; set; } = null!;
    }
}
