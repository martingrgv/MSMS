using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MSMS.Infrastructure.Data.Models;

namespace MSMS.Infrastructure.Data
{
    public class MSMSDbContext(DbContextOptions options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Server> Servers { get; set; } = null!;
        public DbSet<World> World { get; set; } = null!;
        public DbSet<Location> Locations { get; set; } = null!;
        public DbSet<TodoList> TodoLists { get; set; } = null!;
        public DbSet<TodoItem> TodoItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(MSMSDbContext).Assembly);

            base.OnModelCreating(builder);
        }
    }
}
