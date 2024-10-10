using System.ComponentModel.DataAnnotations;
using MSMS.Infrastructure.Data.Enums;
using MSMS.Infrastructure.Data.Models;
using static MSMS.Infrastructure.Constants.ValidationConstants;

namespace MSMS.Core.Models
{
    public class ServerFormModel
    {
        [Required]
        [StringLength(SERVER_NAME_MAX_LENGTH, MinimumLength = SERVER_NAME_MIN_LENGTH, ErrorMessage = "Server name must be between {2} and {1} characters long")]
        public string Name { get; set; } = null!;

        [Required]
        [RegularExpression(@"[\w\d]+\.[\w\d]+\.[\w\d]+(:\d{4,5})?", ErrorMessage = "Invalid IP Address")]
        [StringLength(SERVER_IP_ADDRESS_MAX_LENGTH, MinimumLength = SERVER_IP_ADDRESS_MIN_LENGTH, ErrorMessage = "Invalid IP Address")]
        public string IpAddress { get; set; } = null!;

        [Required]
        [RegularExpression(@"^\d\.\d{1,2}(\.\d)?$", ErrorMessage = "Invalid Version")]
        [StringLength(SERVER_GAME_VERSION_MAX_LENGTH, MinimumLength = SERVER_GAME_VERSION_MIN_LENGTH, ErrorMessage = "Invalid Version")]
        public string GameVersion { get; set;} = null!;

        [Required]
        [EnumDataType(typeof(PlayMode))]
        public PlayMode PlayMode { get; set; }

        [StringLength(DESCRIPTION_MAX_LENGTH, MinimumLength = DESCRIPTION_MIN_LENGTH, ErrorMessage = "Description must be between {2} and {1} characters long.")]
        public string? Description { get; set; }
    }
}
