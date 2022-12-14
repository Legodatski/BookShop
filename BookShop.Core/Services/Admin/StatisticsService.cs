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
            int adminsCount = context.UserRoles.GroupBy(x => x.UserId).Count();

            int totalUserCount = context.Users.Count();

            return totalUserCount - adminsCount;
        }
    }
}
