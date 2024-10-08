using System.ComponentModel.DataAnnotations;
using MSMS.Infrastructure.Data.Enums;
using static MSMS.Infrastructure.Constants.ValidationConstants;

namespace MSMS.Core.Models
{
    public class ServerFormModel
    {
        [Required]
        [StringLength(SERVER_NAME_MAX_LENGTH, MinimumLength = SERVER_NAME_MIN_LENGTH, ErrorMessage = "Server name must be between {2} and {1} characters long.")]
        public string ServerName { get; set; } = null!;

        [Required]
        [StringLength(SERVER_IP_ADDRESS_MAX_LENGTH, MinimumLength = SERVER_IP_ADDRESS_MIN_LENGTH, ErrorMessage = "Server name must be between {2} and {1} characters long.")]
        public string ServerIp { get; set; } = null!;

        [Required]
        [StringLength(SERVER_GAME_VERSION_MAX_LENGTH, MinimumLength = SERVER_GAME_VERSION_MIN_LENGTH, ErrorMessage = "Server name must be between {2} and {1} characters long.")]
        public string GameVersion { get; set;} = null!;

        [Required]
        [EnumDataType(typeof(PlayMode))]
        public PlayMode PlayMode { get; set; }

        [StringLength(DESCRIPTION_MAX_LENGTH, MinimumLength = DESCRIPTION_MIN_LENGTH, ErrorMessage = "Description must be between {2} and {1} characters long.")]
        public string? Description { get; set; }
    }
}
