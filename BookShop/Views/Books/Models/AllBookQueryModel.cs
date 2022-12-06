using BookShop.Data.Entities;
using BookShop.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Views.Books.Models
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

        [Display(Name = "Search By Text")]
        public string? SearchTerm { get; set; }

        public BooksSorting Sorting { get; set; } = 0;

        public SubjectType? Subject { get; set; }

        public IEnumerable<BookViewModel> Books { get; set; }

        public IEnumerable<SubjectType> AllSubjects { get; set; }
    }
}
