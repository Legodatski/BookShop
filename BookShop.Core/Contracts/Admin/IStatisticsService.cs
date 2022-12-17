namespace BookShop.Core.Contracts.Admin
{
    public interface IStatisticsService
    {
        int UsersCount();

        int BooksCount();
    }
}
