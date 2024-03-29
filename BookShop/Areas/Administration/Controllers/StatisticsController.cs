﻿using BookShop.Core.Contracts.Admin;
using BookShop.Core.Models.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class StatisticsController : Controller
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        public IActionResult Statistics()
        {
            StatisticsViewModel model = new StatisticsViewModel()
            {
                UsersCount = statisticsService.UsersCount(),
                BooksCount = statisticsService.BooksCount()
            };

            return View(model);
        }
    }
}
