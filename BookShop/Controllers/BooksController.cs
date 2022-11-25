using BookShop.Data.Entities;
using BookShop.Services.Books;
using BookShop.Views.Books.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookShop.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        public IActionResult Index()
            => RedirectToAction("All");

        public IActionResult All()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value ?? "-";

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
    }
}
