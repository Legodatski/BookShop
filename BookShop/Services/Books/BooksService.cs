using BookShop.Data;
using BookShop.Data.Entities;

namespace BookShop.Services.Books
{
    public class BooksService : IBooksService
    {
        private readonly ApplicationDbContext context;

        public BooksService(ApplicationDbContext applicationDbContext)
        {
            this.context = applicationDbContext;
        }

        public IEnumerable<Book> GetAllNotOwned(string userId)
            => context.Books
            .Where(b => b.OwnerId != userId);

    }
}
