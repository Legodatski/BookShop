
using BookShop.Infrastructure.Entities;
using BookShop.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using NUnit.Framework;

namespace BookShop.NUnitTests
{
    public class BooksServiceTests
    {
        private ApplicationDbContext context;
        private IBooksService booksService;
        private List<Book> books;

        [OneTimeSetUp]
        public void InitializeDb()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "BooksInMemoryDb")
                .Options;

            context = new ApplicationDbContext(options);

            List<User> users = new List<User>()
            {
                new User(){Id = "1", Email = "a@abv.bg", FirstName = "A", LastName = "AA", PhoneNumber = "123"},
                new User(){Id = "2", Email = "b@abv.bg", FirstName = "B", LastName = "BB", PhoneNumber = "456"},
                new User(){Id = "3", Email = "c@abv.bg", FirstName = "C", LastName = "CC", PhoneNumber = "798"}
            };

            context.Users.AddRange(users);

            List<Publisher> publishers = new List<Publisher>()
            {
                new Publisher() { Id = 1, Name = "PublisherA", IsDeleted = false },
                new Publisher() { Id = 2, Name = "PublisherB", IsDeleted = false },
                new Publisher() { Id = 3, Name = "PublisherC", IsDeleted = false }
            };

            context.Publishers.AddRange(publishers);

            List<SubjectType> subjects = new List<SubjectType>()
            {
                new SubjectType(){Id = 1, Name ="SubjectA"},
                new SubjectType(){Id = 2, Name ="SubjectB"},
                new SubjectType(){Id = 3, Name ="SubjectC"}
            };

            context.SubjectTypes.AddRange(subjects);

            books = new List<Book>()
            {
                new Book(){Id=1, BookTypeId=1, Grade=1, OwnerId="1", ImageUrl="URL",
                    PublisherId = 1, Title = "BookA", datePublished = DateTime.Parse("2002-12-20")},
                new Book(){Id=2, BookTypeId=2, Grade=2, OwnerId="2", ImageUrl="URL",
                    PublisherId = 2, Title = "BookB", datePublished = DateTime.Parse("2001-12-20")},
                new Book(){Id=3, BookTypeId=3, Grade=3, OwnerId="3", ImageUrl="URL",
                    PublisherId = 3, Title = "BookC", datePublished = DateTime.Parse("2000-12-20")}
            };

            context.Books.AddRange(books);
            context.SaveChanges();

            booksService = new BooksService(context);
        }

        [Test]
        public void Test_GetLast_CorrectInput()
        {
            var excepted =  new Book()
            {   Id=1, 
                BookTypeId=1, 
                Grade=1, 
                OwnerId="1", 
                ImageUrl="URL",
                PublisherId = 1, 
                Title = "BookA", 
                datePublished = DateTime.Parse("2002-12-20")
            };


            var actual = booksService.GetLast(1).First();

            Assert.True(actual.Id == excepted.Id);
        }

        [Test]
        public void Test_GetLast_InvalidInput()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => booksService.GetLast(0));
        }

        [Test]
        public async Task Test_GetAllBooks_Sorting()
        {
            var excepted = new Book()
            {
                Id = 1,
                BookTypeId = 1,
                Grade = 1,
                OwnerId = "1",
                ImageUrl = "URL",
                PublisherId = 1,
                Title = "BookA",
                datePublished = DateTime.Parse("2002-12-20")
            };

            var query = await  booksService.All(null, null, BooksSorting.Grade, 1, 5);
            var actual = query.Books.First();

            Assert.True(actual.Id == excepted.Id);
        }

        [Test]
        public async Task Test_GetAllBooks_FilterSubject()
        {
            var excepted = new Book()
            {
                Id = 1,
                BookTypeId = 1,
                Grade = 1,
                OwnerId = "1",
                ImageUrl = "URL",
                PublisherId = 1,
                Title = "BookA",
                datePublished = DateTime.Parse("2002-12-20")
            };

            var query = await booksService.All("SubjectA", null, BooksSorting.Grade, 1, 5);
            var actual = query.Books.First();

            Assert.True(actual.Id == excepted.Id);

        }

        [Test]
        public void Test_CurrentUserBooks()
        {
            var actualBooks = booksService.CurrentUserBooks("1");
            var expected = context.Books.FirstOrDefault(b => b.OwnerId == "1");

            Assert.True(expected.Id == actualBooks.First().Id);
        }
    }
}
