using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MSMS.Infrastructure.Data;
using MSMS.Infrastructure.Data.Enums;
using MSMS.Infrastructure.Data.Models;

namespace Microsoft.AspNetCore.Identity;

public static class ApplicationBuilderExtension
{
    public static IApplicationBuilder AddRoles(this IApplicationBuilder app)
    {
        using var scopedServices = app.ApplicationServices.CreateScope();
        var serviceProvider = scopedServices.ServiceProvider;
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        string[] roles = Enum.GetNames<Role>();
        IdentityResult roleResult;

        Task.Run(async () =>
        {
            foreach (var role in roles)
            {
                var roleExists = await roleManager.RoleExistsAsync(role);
                if (roleExists == false)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        })
        .GetAwaiter()
        .GetResult();

        return app;
    }

    public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app, ILogger logger)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            using var dbContext = scope.ServiceProvider.GetRequiredService<MSMSDbContext>();

            try
            {
                dbContext.Database.Migrate();
            }
            catch (SqlException ex)
            {
                logger.LogError("Exception occured upon migrating!", ex);
            }
        }

        return app;
    }
}
