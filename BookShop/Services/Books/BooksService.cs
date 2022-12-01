using BookShop.Data;
using BookShop.Data.Entities;
using BookShop.Views.Books.Models;
using Microsoft.EntityFrameworkCore;

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
            User owner = context.Users.Find(userId);

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
                Owner = owner,
                IsDeleted = false
            };

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public IEnumerable<Book> CurrentUserBooks(string userId)
            => context
            .Books
            .Where(x => x.OwnerId == userId && x.IsDeleted == false);

        public async Task Delete(int id)
        {
            Book book = await context.Books.FindAsync(id);

            book.IsDeleted = true;

            await context.SaveChangesAsync();
        }

        public async Task Edit(BookViewModel model, int id)
        {
            Book book = context.Books.Find(id);

            book.Title = model.Title;
            book.Description = model.Description;
            book.Price = model.Price;
            book.Grade = model.Grade;
            book.SubjectType = await context.SubjectTypes.FirstOrDefaultAsync(x => x.Name == model.Subject);
            book.Publisher = await context.Publishers.FirstOrDefaultAsync(x => x.Name == model.Publisher);

            await context.SaveChangesAsync();
        }

        public IEnumerable<Book> GetAllBooks()
            => context
            .Books
            .Where(x => x.IsDeleted == false);

        public IEnumerable<Book> GetAllNotOwned(string userId)
            => context
            .Books
            .Where(b => b.OwnerId != userId && b.IsDeleted == false);

        public IEnumerable<SubjectType> GetAllSubjectTypes()
            => context
            .SubjectTypes
            .Distinct();

        public async Task<Book> GetBook(int id)
            => await context.Books.FindAsync(id);
        public async Task<SubjectType> GetSubjectType(int Id)
            => await context
            .SubjectTypes
            .FindAsync(Id);
    }
}
