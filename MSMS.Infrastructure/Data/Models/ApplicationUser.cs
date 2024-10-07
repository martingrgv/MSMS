using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static MSMS.Infrastructure.Constants.ValidationConstants;

namespace MSMS.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(FIRSTNAME_MAX_LENGTH)]
        [Comment("User's first name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LASTNAME_MAX_LENGTH)]
        [Comment("User's last name")]
        public string LastName { get; set; } = null!;
    }
}
