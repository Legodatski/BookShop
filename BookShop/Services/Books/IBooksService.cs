using BookShop.Data.Entities;

namespace BookShop.Services.Books
{
    public interface IBooksService
    {
        public IEnumerable<Book> GetAllNotOwned(string userId);
    }
}
