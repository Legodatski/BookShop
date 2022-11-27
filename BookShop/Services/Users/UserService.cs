using BookShop.Data;
using BookShop.Data.Entities;

namespace BookShop.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool ExistsById(string userId)
            => context.Users.Any(user => user.Id == userId);

        public async Task<User> FindById(string userId)
            => await context.Users.FindAsync(userId);
    }
}
