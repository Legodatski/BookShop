using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookShop.Core.Models.Users
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
