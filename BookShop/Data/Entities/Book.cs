using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.BookTitleMaxLenght)]
        [MinLength(GlobalConstants.BookTitleMinLenght)]
        public string Title { get; set; } = null!;
    }
}
