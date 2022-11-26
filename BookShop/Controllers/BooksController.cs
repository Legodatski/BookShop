using BookShop.Data.Entities;
using BookShop.Services.Books;
using BookShop.Services.Publishers;
using BookShop.Views.Books.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;
namespace BookShop.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBooksService booksService;
        private readonly IPublisherService publisherService;

        public BooksController(
            IBooksService booksService,
            IPublisherService publisherService)
        {
            this.booksService = booksService;
            this.publisherService = publisherService;
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

        public IActionResult MyBooks()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value ?? "";

            var books = booksService.CurrentUserBooks(userId);

            List<BookViewModel> model = new List<BookViewModel>();

            foreach (var book in books)
            {
                model.Add(new BookViewModel()
                {
                    Title = book.Title,
                    Price = book.Price,
                    Description = book.Description,
                    Publisher = publisherService.GetPublisher(book.PublisherId).Name,
                    ImageUrl = book.ImageUrl,
                    Grade = book.Grade
                });
            }

            return View(model);
        }
    }
}
