using BookShop.Areas.Administration.Contracts;
using BookShop.Areas.Administration.Models;
using BookShop.Services.Publishers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace BookShop.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;
        private readonly IPublisherService publisherService;

        private string homeViewPath = "/Views/Home/Index.cshtml";

        public AdminController(
            IAdminService adminService, 
            IPublisherService publisherService)
        {
            this.adminService = adminService;
            this.publisherService = publisherService;
        }

        public IActionResult Publishers()
        {
            PublishersViewModel model = new PublishersViewModel()
            {
                Publishers = publisherService.GetAllPublishers()
            };

            return View(model);
        }

        [HttpPost]
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
    }
}
