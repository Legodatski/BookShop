using BookShop.Infrastructure.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedAdmin(
            this IApplicationBuilder app)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider services = scopedServices.ServiceProvider;

            UserManager<User> userManager = services.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
            {
                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    IdentityRole adminRole = new IdentityRole("Admin");
                    await roleManager.CreateAsync(adminRole);
                }

                if (!await roleManager.RoleExistsAsync("User"))
                {
                    IdentityRole userRole = new IdentityRole("User");
                    await roleManager.CreateAsync(userRole);
                }

                User admin = await userManager.FindByEmailAsync("admin@gmail.com");
                await userManager.AddToRoleAsync(admin, "Admin");
            })
            .GetAwaiter()
            .GetResult();

            return app;
        }
    }
}
