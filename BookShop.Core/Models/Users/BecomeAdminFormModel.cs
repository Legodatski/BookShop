using BookShop.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Core.Models.Users
{
    public class BecomeAdminFormModel
    {
        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        public string PhoneNumber { get; set; }
    }
}
