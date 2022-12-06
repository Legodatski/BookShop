using BookShop.Views.Books.Models;

namespace BookShop.Services.Books.Models
{
    public class BooksQueryServiceModel
    {
        public BooksQueryServiceModel()
        {
            Books = new HashSet<BookViewModel>();
        }

        public int TotalBooksCount { get; set; }
        public IEnumerable<BookViewModel> Books { get; set; }
    }
}
