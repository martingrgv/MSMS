﻿using Microsoft.AspNetCore.Identity;
﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MSMS.Core.Contracts;
using MSMS.Core.Profiles;
using MSMS.Core.Services;
using MSMS.Infrastructure.Data;
using MSMS.Infrastructure.Data.Models;
using MSMS.Infrastructure.Common;
using System.Security.Claims;

namespace MSMS.Web.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRepository, Repository>();
            serviceCollection.AddAutoMapper(typeof(ServerProfile).Assembly);
            serviceCollection.AddScoped<IServerService, ServerService>();
            serviceCollection.AddScoped<IStatisticsService, StatisticsService>();
            serviceCollection.AddScoped<ITodoService, TodoService>();

            return serviceCollection;
        }

        public static IServiceCollection AddDbContext(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("MSMSConnectionString") ?? throw new InvalidOperationException("Could not find connection string!");
            serviceCollection.AddDbContext<MSMSDbContext>(options =>
            {
                options.UseSqlServer(connectionString,
                    b => b.MigrationsAssembly("MSMS.Infrastructure"));
            });
            serviceCollection.AddDatabaseDeveloperPageExceptionFilter();

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

        public static IServiceCollection ConfigureRoleClaim(this IServiceCollection serviceCollection)
        {
            serviceCollection.Configure<IdentityOptions>(options => 
            {
                options.ClaimsIdentity.RoleClaimType = ClaimTypes.Role;
            });

            return serviceCollection;
        }
    }
}
