using BookShop.Core.Contracts;
using BookShop.Core.Models.Users;
using BookShop.Infrastructure;
using BookShop.Infrastructure.Entities;
using Ganss.Xss;
using Microsoft.AspNetCore.Identity;

namespace BookShop.Core.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;
        private HtmlSanitizer htmlSanitizer;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
            htmlSanitizer = new HtmlSanitizer();
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

            if (user == null)
                throw new ArgumentNullException("Invalid user");

            user.FirstName = htmlSanitizer.Sanitize(model.FirstName);
            user.LastName = htmlSanitizer.Sanitize(model.LastName);
            user.Email = htmlSanitizer.Sanitize(model.Email);
            user.PhoneNumber = htmlSanitizer.Sanitize(model.PhoneNumber);
            user.SchoolId = model.SchoolId;
            user.TownId = model.TownId;
            user.SchoolId = model.SchoolId;
            user.UserName = model.FirstName + model.LastName;

            await context.SaveChangesAsync();
        }

        public bool ExistsById(string userId)
            => context.Users.Any(user => user.Id == userId);

        public async Task<User> FindById(string userId)
        {
            var user = await context.Users.FindAsync(userId);

            if (user == null)
                throw new ArgumentNullException("Invalid user id");

            return user;
        }
    }
}
