using Microsoft.AspNetCore.Identity;
using MSMS.Infrastructure.Data.Enums;
using MSMS.Infrastructure.Data.Models;

namespace System.Security.Claims
{
    public static class UserExtensions
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier)!;
        }

        public static async Task<ApplicationUser?> GetApplicationUser(this ClaimsPrincipal user, UserManager<ApplicationUser> userManager) => await userManager.FindByIdAsync(user.Id());
    }
}
