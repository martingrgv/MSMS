using MSMS.Infrastructure.Data.Enums;
using MSMS.Infrastructure.Data.Models;

namespace Microsoft.AspNetCore.Identity;

public static class ApplicationBuilderExtension
{
    public static IApplicationBuilder AddRoles(this IApplicationBuilder app)
    {
        using (var scopedServices = app.ApplicationServices.CreateScope())
        {
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
    }
}
