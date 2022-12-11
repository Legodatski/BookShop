using BookShop.Data.Entities;
using BookShop.Views.Account.Models;

namespace BookShop.Contracts
{
    public interface IUserService
    {
        bool ExistsById(string userId);

        Task<User> FindById(string userId);


        Task EditUser(EditUserModel model, string id);

        void CongifureRoles();
    }
}
