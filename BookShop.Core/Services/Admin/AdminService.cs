
using BookShop.Core.Contracts.Admin;
using BookShop.Core.Models.Admin;
using BookShop.Infrastructure;
using BookShop.Infrastructure.Entities;
using Ganss.Xss;
using Microsoft.AspNetCore.Identity;

namespace BookShop.Core.Services.Admin
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext context;
        private HtmlSanitizer htmlSanitizer;

        public AdminService(ApplicationDbContext context)
        {
            this.context = context;
            htmlSanitizer = new HtmlSanitizer();
        }

        public async Task AddRoleToUser(string userId)
        {
            string adminRoleKey = "971ba58d-3ed5-4950-95b6-5e96a734db6f";

            if (!context.Users.Any(u => u.Id == userId))
            {
                throw new ArgumentException("Invalid user");
            }

            await context.UserRoles.AddAsync(new IdentityUserRole<string>()
            {
                RoleId = adminRoleKey,
                UserId = userId
            });

            await context.SaveChangesAsync();
        }

        public async Task AddSchool(SchoolsViewModel model)
        {

            if (!context.Towns.Any(t => t.Id == model.TownId))
            {
                throw new ArgumentException("Invalid town");
            }

            await context.Schools.AddAsync(new School()
            {
                Name = htmlSanitizer.Sanitize(model.Name),
                SchoolType = model.SchoolType,
                TownId = model.TownId,
                IsDeleted = false
            });

            await context.SaveChangesAsync();
        }

        public async Task DeletePublisher(int id)
        {
            Publisher publisher = await context.Publishers.FindAsync(id);

            publisher.IsDeleted = true;

            await context.SaveChangesAsync();
        }

        public async Task DeleteSchool(int id)
        {
            School school = await context.Schools.FindAsync(id);

            school.IsDeleted = true;

            await context.SaveChangesAsync();
        }

        public async Task DeleteTown(int id)
        {
            Town town = await context.Towns.FindAsync(id);

            town.IsDeleted = true;

            await context.SaveChangesAsync();
        }
    }
}
