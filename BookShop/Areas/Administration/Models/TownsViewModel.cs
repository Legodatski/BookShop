﻿using BookShop.Constants;
using BookShop.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Areas.Administration.Models
{
    public class TownsViewModel
    {
        public TownsViewModel()
        {
            Towns = new HashSet<Town>();
        }

        [Required]
        [MaxLength(GlobalConstants.TownNameMaxLenght)]
        [MinLength(GlobalConstants.TownNameMinLenght)]
        public string Name { get; set; }

        public IEnumerable<Town> Towns { get; set; }
    }
}
