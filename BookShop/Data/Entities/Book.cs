using BookShop.Constants;
using BookShop.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Data.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(GlobalConstants.BookTitleMaxLenght)]
        [MinLength(GlobalConstants.BookTitleMinLenght)]
        public string Title { get; set; } = null!;

        public string Description { get; set; }

        [Required]
        [Range(GlobalConstants.BookYearMin, GlobalConstants.BookYearMax)]
        public int Year { get; init; }


        [Required]
        [Range(GlobalConstants.BookGradeMin, GlobalConstants.BookGradeMax)]
        public int Grade { get; set; }

        public virtual User Owner { get; set; } = null!;

        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; } = null!;

        [Range(GlobalConstants.BookPriceMin, GlobalConstants.BookPriceMax)]
        public decimal Price { get; set; }

        [Required]
        public Publisher Publisher { get; set; } = null!;

        [ForeignKey(nameof(Publisher))]
        public int PublisherId { get; set; }

        [Required]
        public SubjectType SubjectType { get; set; } = null!;

        [ForeignKey(nameof(SubjectType))]
        public int BookTypeId { get; set; }

        public DateTime datePublished { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public string? ImageUrl { get; set; }
    }
}
