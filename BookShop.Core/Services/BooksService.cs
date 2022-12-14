using BookShop.Core.Contracts;
using BookShop.Core.Models.Books;
using BookShop.Infrastructure;
using BookShop.Infrastructure.Entities;
using BookShop.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Core.Services
{
    public class BooksService : IBooksService
    {
        private readonly ApplicationDbContext context;

        public BooksService(
            ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Add(AddBookViewModel model, string userId)
        {
            User? owner = context.Users.Find(userId);

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
                Year = model.Year,
                IsDeleted = false
            };

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public async Task<BooksQueryServiceModel> All(
            string? subject = null,
            string? searchTerm = null,
            BooksSorting sorting = BooksSorting.Newest,
            int currentPage = 1,
            int booksPerPage = 5)
        {
            var bookQuery = context.Books.AsQueryable();

            if (subject != null)
            {
                bookQuery = context.Books.Where(x => x.SubjectType.Name == subject);
            }

            if (searchTerm != null)
            {
                bookQuery = context.Books.Where(h =>
                h.Title.ToLower().Contains(searchTerm.ToLower()) ||
                h.Owner.UserName.ToLower().Contains(searchTerm.ToLower()) ||
                h.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            bookQuery = sorting switch
            {
                BooksSorting.Newest => bookQuery.OrderByDescending(x => x.datePublished),
                BooksSorting.Grade => bookQuery.OrderBy(x => x.Grade),
                BooksSorting.Name => bookQuery.OrderBy(x => x.Title),
                BooksSorting.Price => bookQuery.OrderBy(x => x.Price),
                BooksSorting.PublisherName => bookQuery.OrderBy(x => x.Publisher.Name),
                BooksSorting.Location => bookQuery.OrderBy(x => x.Owner.Town.Name)
            };

            var books = bookQuery
                .Skip((currentPage - 1) * booksPerPage)
                .Take(booksPerPage);

            List<BookViewModel> booksModel = new List<BookViewModel>();

            foreach (var book in books)
            {
                booksModel.Add(await BookToViewModel(book));
            }

            BooksQueryServiceModel query = new BooksQueryServiceModel
            {
                TotalBooksCount = booksModel.Count(),
                Books = booksModel
            };

            return query;
        }

        public async Task<BookViewModel> BookToViewModel(Book book)
        {
            var owner = await context.Users.FirstOrDefaultAsync(o => o.Id == book.OwnerId);
            var publisher = await context.Publishers.FindAsync(book.PublisherId);
            var subject = await context.SubjectTypes.FindAsync(book.BookTypeId);

            var modelBook = new BookViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Price = book.Price,
                Description = book.Description,
                Publisher = publisher?.Name,
                Grade = book.Grade,
                OwnerId = owner?.Id,
                Created = book.datePublished,
                ImageUrl = book.ImageUrl,
                Owner = owner,
                Subject = subject?.Name
            };

            return modelBook;
        }

        public IEnumerable<Book> CurrentUserBooks(string userId)
            => context
            .Books
            .Where(x => x.OwnerId == userId && x.IsDeleted == false);

        public async Task Delete(int id)
        {
            Book? book = await context.Books.FindAsync(id);

            book.IsDeleted = true;

            await context.SaveChangesAsync();
        }

        public async Task Edit(AddBookViewModel model)
        {
            Book? book = context.Books.Find(model.Id);

            book.Title = model.Title;
            book.Description = model.Description;
            book.Price = model.Price;
            book.Grade = model.Grade;
            book.ImageUrl = model.ImageUrl;
            book.SubjectType = await context?.SubjectTypes?.FirstOrDefaultAsync(x => x.Id == model.SubjectId);
            book.Publisher = await context.Publishers.FirstOrDefaultAsync(x => x.Id == model.PublisherId);

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

        public IEnumerable<Book> GetLast(int n)
            => context
            .Books
            .OrderBy(x => x.datePublished)
            .Take(n);

        public async Task<SubjectType> GetSubjectType(int Id)
            => await context
            .SubjectTypes
            .FindAsync(Id);
    }
}
