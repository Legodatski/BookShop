﻿using BookShop.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Infrastructure.Entities
{
    public class Publisher
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(GlobalConstants.PublisherNameMaxLenght)]
        [MinLength(GlobalConstants.PublisherNameMinLenght)]
        public string Name { get; init; } = null!;

        public bool IsDeleted { get; set; }
    }
}
