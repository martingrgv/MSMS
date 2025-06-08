using Microsoft.AspNetCore.Identity;

namespace MSMS.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public ICollection<Server> Servers { get; set; } = [];
        public ICollection<Location> Locations { get; set; } = [];
        public ICollection<TodoList> TodoLists { get; set; } = [];
    }
}
