using BookShop.Data;

namespace BookShop.Services.User
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
    }
}
