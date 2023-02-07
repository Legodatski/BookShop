using BookShop.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookShop.Core.Models.Users
{
    public class LoginModel
    {
        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
