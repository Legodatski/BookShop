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
            AllPublishers = new HashSet<Publisher>();
        }

        public int? Id { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        [MaxLength(GlobalConstants.BookTitleMaxLenght)]
        [MinLength(GlobalConstants.BookTitleMinLenght)]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        public int PublisherId { get; set; }

        public IEnumerable<Publisher> AllPublishers { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        [Range(0, int.MaxValue)]
        public decimal Price  { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        [Range(1,12)]
        public int Grade { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        public int SubjectId { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        public int Year { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        public IEnumerable<SubjectType> AllSubjects { get; set; }
    }
}
