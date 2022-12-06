using BookShop.Data.Entities;

namespace BookShop.Services.Users
{
    public interface IUserService
    {
        bool ExistsById(string userId);

        Task<User> FindById(string userId);
    }
}
