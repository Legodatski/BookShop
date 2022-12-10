using BookShop.Data.Entities;

namespace BookShop.Views.Books.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }
        public decimal Price { get; set; }

        public string? Publisher { get; set; }

        public int Grade { get; set; }

        public string? ImageUrl { get; set; }
        public string? Subject { get; set; }

        public DateTime Created { get; set; }

        public string? OwnerId { get; set; }
        public User? Owner { get; set; }
    }
}
