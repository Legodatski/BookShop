using BookShop.Infrastructure.Constants;
using BookShop.Infrastructure.Entities;
using BookShop.Infrastructure.Extensions;
using System.ComponentModel.DataAnnotations;
namespace BookShop.Core.Models.Users
{
    public class RegisterModel
    {
        public RegisterModel()
        {
            Towns = new HashSet<Town>();
            Schools = new HashSet<School>();
        }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        [Display(Name = "First Name")]
        [MinLength(GlobalConstants.FirstNameMinLenght)]
        [MaxLength(GlobalConstants.FirstNameMaxLenght)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        [Display(Name = "Last Name")]
        [MinLength(GlobalConstants.LastNameMinLenght)]
        [MaxLength(GlobalConstants.LastNameMaxLenght)]
        public string LastName { get; set; }


        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        [DataType(DataType.Password)]
        [MinLength(GlobalConstants.PasswordMinLenght)]
        [MaxLength(GlobalConstants.PasswordMaxLenght)]
        public string Password { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        [Display(Name = "Town")]
        public int TownId { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        [Display(Name = "School")]
        public int SchoolId { get; set; }

        public IEnumerable<School> Schools { get; set; }

        public IEnumerable<Town> Towns { get; set; }

        [StringLenghtExact(Lenght = GlobalConstants.PhoneLenght)]
        [Display(Name ="Phone Number")]
        public string? PhoneNumber { get; set; }

    }
}
