using BookShop.Infrastructure.Entities;
using BookShop.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Core.Models.Books
{
    public class AllBookQueryModel
    {
        public const int BooksPerPage = 5;

        public AllBookQueryModel()
        {
            Books = new HashSet<BookViewModel>();
            AllSubjects = new HashSet<SubjectType>();
        }

        public int TotalBooksCount { get; set; }

        public int CurrentPage { get; set; } = 1;

        [Display(Name = "Търси по текст")]
        public string? SearchTerm { get; set; }

        public BooksSorting Sorting { get; set; } = 0;

        public string Subject { get; set; }

        public IEnumerable<BookViewModel> Books { get; set; }

        public IEnumerable<SubjectType> AllSubjects { get; set; }
    }
}
