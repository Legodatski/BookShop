using BookShop.Data.Entities;
using BookShop.Data;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookShop.Views.Accounts.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MinLength(GlobalConstants.FirstNameMinLenght)]
        [MaxLength(GlobalConstants.FirstNameMaxLenght)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MinLength(GlobalConstants.LastNameMinLenght)]
        [MaxLength(GlobalConstants.LastNameMaxLenght)]
        public string LastName { get; set; }

        [Required]
        public int TownId { get; set; }

        public IEnumerable<Town> Towns { get; set; }
    }
}
