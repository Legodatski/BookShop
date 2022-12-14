using BookShop.Infrastructure.Constants;
using BookShop.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Core.Models.Books
{
    public class AddBookViewModel
    {
        public AddBookViewModel()
        {
            AllSubjects = new HashSet<SubjectType>();
        }

        public int? Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.BookTitleMaxLenght)]
        [MinLength(GlobalConstants.BookTitleMinLenght)]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public int PublisherId { get; set; }

        public IEnumerable<Publisher> AllPublishers { get; set; } = null!;

        [Required]
        public decimal Price  { get; set; }

        [Required]
        [Range(1,12)]
        public int Grade { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public IEnumerable<SubjectType> AllSubjects { get; set; }
    }
}
