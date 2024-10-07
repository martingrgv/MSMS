using MSMS.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MSMS.Infrastructure.Constants.ValidationConstants;

namespace MSMS.Infrastructure.Data.Models
{
    public class Server
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(SERVER_NAME_MAX_LENGTH)]
        public string Name { get; set; } = null!;

        public string ImagePath { get; set; } = null!;

        [Required]
        [MaxLength(SERVER_IP_ADDRESS_MAX_LENGTH)]
        public string IpAddress { get; set; } = null!;

        [Required]
        [MaxLength(SERVER_GAME_VERSION_MAX_LENGTH)]
        public string GameVersion { get; set; } = null!;

        [Required]
        public PlayMode PlayMode { get; set; }

        [MaxLength(DESCRIPTION_MAX_LENGTH)]
        public string? Description { get; set; } = null!;

        [Required]
        public string OwnerId { get; set; } = null!;

        [ForeignKey(nameof(OwnerId))]
        public ApplicationUser Owner { get; set; } = null!;

        public ICollection<World> Worlds { get; set; } = new List<World>();
    }
}
