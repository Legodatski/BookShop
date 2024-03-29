﻿
using BookShop.Core.Contracts;
using BookShop.Core.Models.Books;
using BookShop.Core.Models.Users;
using BookShop.Infrastructure.Entities;
using Ganss.Xss;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace BookShop.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly ITownsService townsService;
        private readonly IUserService userService;
        private readonly IBooksService booksService;

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        private HtmlSanitizer htmlSanitizer;

        public UsersController(
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

            htmlSanitizer = new HtmlSanitizer();
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
                UserName = htmlSanitizer.Sanitize(model.FirstName) + htmlSanitizer.Sanitize(model.LastName),
                FirstName = htmlSanitizer.Sanitize(model.FirstName),
                LastName = htmlSanitizer.Sanitize(model.LastName),
                Email = htmlSanitizer.Sanitize(model.Email),
                PhoneNumber = htmlSanitizer.Sanitize(model.PhoneNumber),
                SchoolId = model.SchoolId,
                TownId = model.TownId
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "User");
                return RedirectToAction("Login", "Users");
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

            var user =  await userManager.FindByEmailAsync(htmlSanitizer.Sanitize(model.Email));

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
                Phone = user.PhoneNumber,
                School = school?.Name ?? "No information is given",
                Town = town.Name
            };

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            string? userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value ?? "";

            User user = await userService.FindById(userId);
            Town town = await townsService.GetTownById(user.TownId);
            School school = await townsService.FindSchoolById(user.SchoolId);

            string schoolName = "No given information";
            string phone = "No given information";

            if (user.PhoneNumber != null)
            {
                phone = user.PhoneNumber;
            }

            if (school != null)
            {
                schoolName = school.Name;
            }

            EditUserModel model = new EditUserModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = phone,
                Schools = townsService.GetAllSchools(),
                TownName = town.Name,
                SchoolName = schoolName,
                Towns = townsService.GetAll()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserModel model)
        {
            string? userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value ?? "";

            if (userId == null || !ModelState.IsValid)
            {
                return RedirectToAction(nameof(Edit));
            }

            await userService.EditUser(model, userId);

            return RedirectToAction(nameof(Edit));            
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
