using BookShop.Data.Entities;
using BookShop.Views.Books.Models;

namespace BookShop.Services.Books
{
    public interface IBooksService
    {
        public IEnumerable<Book> GetAllNotOwned(string userId);

        public IEnumerable<SubjectType> GetAllSubjectTypes();

        public IEnumerable<Book> CurrentUserBooks(string userId);

        public Task Add(AddBookViewModel model, string userId);

        public Task<SubjectType> GetSubjectType(int Id);

        public Task Delete(int id);
    }
}
