
using BookShop.Core.Contracts.Admin;
using BookShop.Core.Models.Admin;
using BookShop.Infrastructure;
using BookShop.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookShop.Core.Services.Admin
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext context;

        public AdminService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddRoleToUser(string userId)
        {
            string adminRoleKey = "971ba58d-3ed5-4950-95b6-5e96a734db6f";

            if (!context.Roles.Any(r => r.Id == adminRoleKey))
            {
                throw new ArgumentException("The database doesn't contain this role");
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
            await context.Schools.AddAsync(new School()
            {
                Name = model.Name,
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
