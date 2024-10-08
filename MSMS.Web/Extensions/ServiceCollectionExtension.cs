using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MSMS.Core.Contracts;
using MSMS.Core.Services;
using MSMS.Infrastructure.Data;
using MSMS.Infrastructure.Data.Models;

namespace MSMS.Web.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRepository, Repository>();
            serviceCollection.AddScoped<IServerService, ServerService>();

            return serviceCollection;
        }

        public static IServiceCollection AddDbContext(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("MSMSConnectionString");
            string macConnectionString = configuration.GetConnectionString("MSMSMacConnectionString");
            serviceCollection.AddDbContext<MSMSDbContext>(options =>
                options.UseSqlServer(macConnectionString));

            return serviceCollection;
        }

        public static IServiceCollection AddIdentity(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<MSMSDbContext>();

            return serviceCollection;
        }
    }
}
