using BookShop.Data.Entities;
using BookShop.Services.Books;
using BookShop.Services.Publishers;
using BookShop.Services.Users;
using BookShop.Views.Books.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace BookShop.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBooksService booksService;
        private readonly IPublisherService publisherService;
        private readonly IUserService userService;

        public BooksController(
            IBooksService booksService,
            IPublisherService publisherService,
            IUserService userService)
        {
            this.booksService = booksService;
            this.publisherService = publisherService;
            this.userService = userService;
        }

        [AllowAnonymous]
        public IActionResult Index()
            => RedirectToAction("All");

        [AllowAnonymous]
        public IActionResult All()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value ?? "";

            var books = booksService.GetAllNotOwned(userId);

            List<BookViewModel> model = new List<BookViewModel>();

            foreach (var book in books)
            {
                model.Add(new BookViewModel()
                {
                    Title = book.Title,
                    Price = book.Price,
                    Description = book.Description,
                    Publisher = book.Publisher.Name,
                    Grade = book.Grade
                });
            }

            return View(model);
        }

        public IActionResult Add()
        {
            AddBookViewModel model = new AddBookViewModel();

            model.AllPublishers = publisherService.GetAllPublishers();

            model.AllSubjects = booksService.GetAllSubjectTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? null;

            if (userId == null)
            {
                return RedirectToAction("Account", "Login");
            }

            await booksService.Add(model, userId);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> MyBooks()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value ?? "";

            User user = await userService.FindById(userId);

            var books = booksService.CurrentUserBooks(userId);

            List<BookViewModel> model = new List<BookViewModel>();

            foreach (var book in books)
            {
                var subject = await booksService.GetSubjectType(book.BookTypeId);

                model.Add(new BookViewModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Price = book.Price,
                    Description = book.Description,
                    Publisher = publisherService.GetPublisher(book.PublisherId).Name,
                    ImageUrl = book.ImageUrl,
                    Owner = user,
                    Created = book.datePublished,
                    Subject = subject.Name.ToString(),
                    Grade = book.Grade
                });
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
    }
}
