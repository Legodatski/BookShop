
namespace BookShop.Core.Models.Books
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
