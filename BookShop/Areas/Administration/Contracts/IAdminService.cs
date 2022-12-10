using BookShop.Areas.Administration.Models;

namespace BookShop.Areas.Administration.Contracts
{
    public interface IAdminService
    {
        Task AddSchool(SchoolsViewModel model);

        Task AddRoleToUser(string userId);
    }
}
