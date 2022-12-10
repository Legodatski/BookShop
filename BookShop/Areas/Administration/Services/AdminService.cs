using BookShop.Areas.Administration.Contracts;
using BookShop.Areas.Administration.Models;
using BookShop.Data;
using BookShop.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookShop.Areas.Administration.Services
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
    }
}
