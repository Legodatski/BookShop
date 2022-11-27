using AutoMapper;
using BookShop.Data.Entities;
using BookShop.Services.Towns;
using BookShop.Services.Users;
using BookShop.Views.Account.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly ITownsService townsService;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(
            ITownsService townsService, 
            UserManager<User> userManager, 
            SignInManager<User> signInManager)
        {
            this.townsService = townsService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            var model = new RegisterModel();

            model.Towns = townsService.GetAll(); 

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user = new User()
            {
                UserName = model.FirstName + model.LastName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                TownId = model.TownId
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "User");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }

        public IActionResult Login()
            => View(new LoginModel());

        [HttpPost]
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
    }
}
