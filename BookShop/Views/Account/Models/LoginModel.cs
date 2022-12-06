using BookShop.Data;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookShop.Views.Account.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(GlobalConstants.PasswordMinLenght)]
        [MaxLength(GlobalConstants.PasswordMaxLenght)]
        public string Password { get; set; }
    }
}
