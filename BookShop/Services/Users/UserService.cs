using BookShop.Data;
using BookShop.Data.Entities;
using BookShop.Views.Account.Models;
using Microsoft.AspNetCore.Identity;

namespace BookShop.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void CongifureRoles()
        {
            var AdminRole = new IdentityRole() 
            { 
                Name = "Admin" 
            };

            if (!context.Roles.Contains(AdminRole))
            {
                context.Roles.Add(AdminRole);
            }


        }

        public async Task EditUser(EditUserModel model, string id)
        {
            var user = await context.Users.FindAsync(id);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.SchoolId = model.SchoolId;
            user.UserName = model.FirstName + " " + model.LastName;

            await context.SaveChangesAsync();
        }

        public bool ExistsById(string userId)
            => context.Users.Any(user => user.Id == userId);

        public async Task<User> FindById(string userId)
            => await context.Users.FindAsync(userId);

    }
}
