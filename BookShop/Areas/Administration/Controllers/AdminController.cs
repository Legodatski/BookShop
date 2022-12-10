﻿using BookShop.Areas.Administration.Contracts;
using BookShop.Areas.Administration.Models;
using BookShop.Data.Entities;
using BookShop.Data.Enums;
using BookShop.Services.Books;
using BookShop.Services.Publishers;
using BookShop.Services.Towns;
using BookShop.Services.Users;
using BookShop.Views.Account.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace BookShop.Areas.Administration.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;
        private readonly IPublisherService publisherService;
        private readonly IBooksService booksService;
        private readonly ITownsService townsService;
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;

        public AdminController(
            IAdminService adminService,
            IPublisherService publisherService,
            IBooksService booksService,
            ITownsService townsService,
            IUserService userService,
            UserManager<User> userManager)
        {
            this.adminService = adminService;
            this.publisherService = publisherService;
            this.booksService = booksService;
            this.townsService = townsService;
            this.userService = userService;
            this.userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Publishers()
        {
            PublishersViewModel model = new PublishersViewModel()
            {
                Publishers = publisherService.GetAllPublishers()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Publishers(PublishersViewModel model)
        {
            model.Publishers = publisherService.GetAllPublishers();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (publisherService.ExistsByName(model.Name))
            {
                ModelState.AddModelError("", "Publisher with that name already exists!");
                return View(model);
            }

            await publisherService.AddPublisher(model.Name);

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Schools()
        {
            SchoolsViewModel model = new SchoolsViewModel()
            {
                AllSchoolTypes = new List<SchoolTypes>()
                {
                    SchoolTypes.MiddleSchool,
                    SchoolTypes.HighSchool,
                    SchoolTypes.PrimarySchool
                },
                AllTowns = townsService.GetAll(),
                Schools = townsService.GetAllSchools()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Schools(SchoolsViewModel model)
        {
            model.AllSchoolTypes = new List<SchoolTypes>()
                {
                    SchoolTypes.MiddleSchool,
                    SchoolTypes.HighSchool,
                    SchoolTypes.PrimarySchool
                };

            model.AllTowns = townsService.GetAll();
            model.Schools = townsService.GetAllSchools();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (townsService.ExistsSchoolByName(model.Name))
            {
                ModelState.AddModelError("", "School with that name already exists!");
                return View(model);
            }

            await adminService.AddSchool(model);

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Towns()
        {
            TownsViewModel model = new TownsViewModel()
            {
                Towns = townsService.GetAll()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Towns(TownsViewModel model)
        {
            model.Towns = townsService.GetAll();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (townsService.ExistsTownByName(model.Name))
            {
                ModelState.AddModelError("", "Town with that name already exists!");
                return View(model);
            }

            await townsService.AddTown(model.Name);

            return RedirectToAction("Towns");
        }

        [Authorize]
        public IActionResult BecomeAdmin()
            => View();

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> BecomeAdmin(BecomeAdminFormModel model)
        {
            string? userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value ?? "";

            if (!ModelState.IsValid && userId is null)
            {
                return View(model);
            }

            User user = await userService.FindById(userId);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid user!");
                return View(model);
            }
            user.PhoneNumber = model.PhoneNumber;

            await adminService.AddRoleToUser(userId);

            return RedirectToAction("Login", "Account");
        }
    }
}
