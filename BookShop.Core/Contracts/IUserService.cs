using BookShop.Core.Models.Users;
using BookShop.Infrastructure.Entities;

namespace BookShop.Core.Contracts
{
    public interface IUserService
    {
        bool ExistsById(string userId);

        Task<User> FindById(string userId);


        Task EditUser(EditUserModel model, string id);

        void CongifureRoles();
    }
}
