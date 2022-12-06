namespace BookShop.Views.Books.Models
{
    public class AllBookViewModel
    {
        public AllBookViewModel()
        {
            Books = new HashSet<BookViewModel>();
        }

        public IEnumerable<BookViewModel> Books { get; set; }
    }
}
