using BookShop.Data.Entities;
using BookShop.Data;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Views.Account.Models
{
    public class RegisterModel
    {
        public RegisterModel()
        {
            Towns = new HashSet<Town>();
        }

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
        [DataType(DataType.Password)]
        [MinLength(GlobalConstants.PasswordMinLenght)]
        [MaxLength(GlobalConstants.PasswordMaxLenght)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [MinLength(GlobalConstants.PasswordMinLenght)]
        [MaxLength(GlobalConstants.PasswordMaxLenght)]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Town")]
        public int TownId { get; set; }

        public IEnumerable<Town> Towns { get; set; }
    }
}
