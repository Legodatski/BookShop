namespace BookShop.Services.User
{
    public interface IUserService
    {
        bool ExistsById(string userId);
    }
}
