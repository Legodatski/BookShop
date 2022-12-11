using BookShop.Data.Entities;
using BookShop.Data.Enums;
using BookShop.Services.Books.Models;
using BookShop.Views.Books.Models;

namespace BookShop.Contracts
{
    public interface IBooksService
    {
        public Task<Book> GetBook(int id);

        public IEnumerable<Book> GetAllBooks();

        public IEnumerable<Book> GetAllNotOwned(string userId);

        public IEnumerable<SubjectType> GetAllSubjectTypes();

        public IEnumerable<Book> CurrentUserBooks(string userId);

        public Task Add(AddBookViewModel model, string userId);

        public Task<SubjectType> GetSubjectType(int Id);

        public Task Delete(int id);

        public Task Edit(AddBookViewModel model);

        public Task<BooksQueryServiceModel> All(
            string? subject = null,
            string? searchTerm = null,
            BooksSorting sorting = BooksSorting.Newest,
            int currentPage = 1,
            int booksPerPage = 5);

        public IEnumerable<Book> GetLast(int n);

        public Task<BookViewModel> BookToViewModel(Book book);
    }
}
