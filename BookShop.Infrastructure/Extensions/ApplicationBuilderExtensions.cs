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

                User admin = await userManager.FindByEmailAsync("admin1@gmail.com");
                User guest = await userManager.FindByEmailAsync("guest@gmail.com");


                if (admin == null)
                {
                    await userManager.CreateAsync(new User()
                    {
                        Id = "35bbae7d-b2a0-472a-8137-e8df5f4ac614",
                        FirstName = "Admin",
                        LastName = "Adminov",
                        SchoolId = null,
                        TownId = 1,
                        Email = "admin1@gmail.com",
                        IsDeleted = false,
                        UserName = "AdminAdminov"
                    }, "admin123");
                }

                if (guest == null)
                {
                    await userManager.CreateAsync(new User()
                    {
                        Id = "a754571d-5a65-433b-ae02-fc356f354448",
                        FirstName = "Pesho",
                        LastName = "Pesho",
                        SchoolId = 2,
                        TownId = 1,
                        Email = "guest@gmail.com",
                        IsDeleted = false,
                        UserName = "PeshoPeshov"
                    }, "guest123");
                }

                await userManager.AddToRoleAsync(admin, "Admin");
                await userManager.AddToRoleAsync(guest, "User");
            })
            .GetAwaiter()
            .GetResult();

            return app;
        }
    }
}
