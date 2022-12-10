namespace BookShop.Areas.Administration.Contracts
{
    public interface IStatisticsService
    {
        int UsersCount();

        int BooksCount();
    }
}
