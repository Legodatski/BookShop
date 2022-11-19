using BookShop.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Entities
{
    public class School
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.SchoolNameMaxLenght)]
        [MinLength(GlobalConstants.SchoolNameMinLenght)]
        public string Name { get; set; } = null!;

        [Required]
        public string Town { get; set; } = null!;

        [Required]
        public SchoolTypes SchoolType { get; set; }
    }
}