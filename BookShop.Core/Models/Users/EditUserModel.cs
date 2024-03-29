﻿using BookShop.Infrastructure.Constants;
using BookShop.Infrastructure.Entities;
using BookShop.Infrastructure.Extensions;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Core.Models.Users
{
    public class EditUserModel
    {
        public EditUserModel()
        {
            Schools = new HashSet<School>();
            Towns = new HashSet<Town>();
        }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        [MaxLength(GlobalConstants.FirstNameMaxLenght)]
        [MinLength(GlobalConstants.FirstNameMinLenght)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        [MaxLength(GlobalConstants.LastNameMaxLenght)]
        [MinLength(GlobalConstants.LastNameMinLenght)]
        public string LastName { get; set; }

        [StringLenghtExact(Lenght = GlobalConstants.PhoneLenght)]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        public int SchoolId { get; set; }

        public IEnumerable<School> Schools { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        public int TownId { get; set; }

        public IEnumerable<Town> Towns { get; set; }
        public string? TownName { get; set; }
        public string? SchoolName { get; set; }
    }
}
