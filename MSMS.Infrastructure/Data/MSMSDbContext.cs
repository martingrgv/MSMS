using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MSMS.Infrastructure.Data.Configurations;
using MSMS.Infrastructure.Data.Models;

namespace MSMS.Infrastructure.Data
{
    public class MSMSDbContext : IdentityDbContext<ApplicationUser>
    {
        public MSMSDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Server> Servers { get; set; } = null!;
        public DbSet<World> World { get; set; } = null!;
        public DbSet<Location> Locations { get; set; } = null!;
        public DbSet<TodoList> TodoLists { get; set; } = null!;
        public DbSet<TodoItem> TodoItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new ServerConfiguration());
            builder.ApplyConfiguration(new WorldConfiguration());
            builder.ApplyConfiguration(new LocationConfiguration());
        }
    }
}
