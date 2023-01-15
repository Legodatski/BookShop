using BookShop.Core.Contracts.Admin;
using BookShop.Infrastructure;

namespace BookShop.Core.Services.Admin
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext context;

        public StatisticsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int BooksCount()
            => context
            .Books
            .Where(x => x.IsDeleted == false)
            .Count();

        public int UsersCount()
        {
            string adminId = "971ba58d-3ed5-4950-95b6-5e96a734db6f";

            int adminsCount = context.UserRoles.Where(u => u.RoleId == adminId).GroupBy(u => u.UserId).Count();

            int totalUserCount = context.Users.Count();

            return totalUserCount - adminsCount;
        }
    }
}
