using AutoMapper;
using BookShop.Data.Entities;
using BookShop.Services.Books;
using BookShop.Services.Towns;
using BookShop.Services.Users;
using BookShop.Views.Account.Models;
using BookShop.Views.Books.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace BookShop.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ITownsService townsService;
        private readonly IUserService userService;
        private readonly IBooksService booksService;

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(
            ITownsService townsService, 
            UserManager<User> userManager, 
            SignInManager<User> signInManager,
            IUserService userService,
            IBooksService booksService)
        {
            this.booksService = booksService;
            this.userService = userService;
            this.townsService = townsService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            var model = new RegisterModel();

            model.Towns = townsService.GetAll();
            model.Schools = townsService.GetAllSchools();


            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            model.Schools = townsService.GetAllSchools();
            model.Towns = townsService.GetAll();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user = new User()
            {
                //ne moje username da ima " "{space} 
                UserName = model.FirstName + model.LastName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                SchoolId = model.SchoolId,
                TownId = model.TownId
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Login()
            => View(new LoginModel());

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user =  await userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                await signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public async Task<IActionResult> Details(string id)
        {
            var user = await userService.FindById(id);
            var school = await townsService.FindSchoolById(user.SchoolId);
            var town = await townsService.GetTownById(user.TownId);
            var books = booksService.CurrentUserBooks(id);

            List<BookViewModel> booksModels = new List<BookViewModel>();

            foreach (var book in books)
            {
                booksModels.Add(await booksService.BookToViewModel(book));
            }

            DetailsUserModel model = new DetailsUserModel()
            {
                Id = id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Books = booksModels,
                School = school?.Name ?? "No information is given",
                Town = town.Name
            };

            return View(model);
        }

        public IActionResult Edit(string id)
        {
            EditUserModel model = new EditUserModel()
            {
                Id = id,
                Schools = townsService.GetAllSchools(),
                Towns = townsService.GetAll()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserModel model)
        {
            string? userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value ?? "";

            await userService.EditUser(model, userId);

            return RedirectToAction("MyBooks", "Books");            
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
