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
        public string Title { get; init; } = null!;

        public string? Description { get; set; }

        [Required]
        [Range(GlobalConstants.BookYearMin, GlobalConstants.BookYearMax)]
        public int Year { get; init; }


        [Required]
        [Range(GlobalConstants.BookGradeMin, GlobalConstants.BookGradeMax)]
        public int Grade { get; init; }

        public virtual User Owner { get; init; } = null!;

        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; init; } = null!;

        [Range(GlobalConstants.BookPriceMin, GlobalConstants.BookPriceMax)]
        public decimal Price { get; init; }

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
    }
}
