using BookShop.Data;
using BookShop.Data.Entities;
using BookShop.Views.Books.Models;

namespace BookShop.Services.Books
{
    public class BooksService : IBooksService
    {
        private readonly ApplicationDbContext context;

        public BooksService(ApplicationDbContext applicationDbContext)
        {
            this.context = applicationDbContext;
        }

        public async Task Add(AddBookViewModel model, string userId)
        {
            Book book = new Book()
            {
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                BookTypeId = model.SubjectId,
                PublisherId = model.SubjectId,
                Grade = model.Grade,
                datePublished = DateTime.Today,
                OwnerId = userId,
                IsDeleted = false
            };

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public IEnumerable<Book> CurrentUserBooks(string userId)
            => context.Books.Where(x => x.OwnerId == userId && x.IsDeleted == false);

        public IEnumerable<Book> GetAllNotOwned(string userId)
            => context.Books
            .Where(b => b.OwnerId != userId && b.IsDeleted == false);

        public IEnumerable<SubjectType> GetAllSubjectTypes()
            => context.SubjectTypes.Distinct();

    }
}
