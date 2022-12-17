using BookShop.Core.Models.Admin;

namespace BookShop.Core.Contracts.Admin
{
    public interface IAdminService
    {
        Task AddSchool(SchoolsViewModel model);

        Task AddRoleToUser(string userId);

        Task DeleteSchool(int id);
        Task DeleteTown(int id);
        Task DeletePublisher(int id);
    }
}
