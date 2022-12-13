
using BookShop.Core.Contracts;
using BookShop.Core.Models.Books;
using BookShop.Infrastructure.Entities;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookShop.Controllers
{
    public class HomeController : Controller
    {
        private IBooksService booksService;

        public HomeController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        public async Task<IActionResult> Index()
        {
            List<Book> books = new List<Book>();

            books.AddRange(booksService.GetLast(3).ToList());

            List<BookViewModel> model = new List<BookViewModel>();

            foreach (var book in books)
            {
                model.Add(await booksService.BookToViewModel(book));
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}