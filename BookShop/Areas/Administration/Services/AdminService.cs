using BookShop.Areas.Administration.Contracts;
using BookShop.Data;
using BookShop.Data.Entities;

namespace BookShop.Areas.Administration.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext context;

        public AdminService(ApplicationDbContext context)
        {
            this.context = context;
        }
    }
}
