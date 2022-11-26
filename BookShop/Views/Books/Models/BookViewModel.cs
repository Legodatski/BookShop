namespace BookShop.Views.Books.Models
{
    public class BookViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }

        public string Publisher { get; set; }

        public string Author { get; set; }

        public int Grade { get; set; }

        public string ImageUrl { get; set; }
        public string Subject { get; set; }
    }
}
