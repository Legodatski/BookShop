using System.ComponentModel.DataAnnotations;

namespace BookShop.Core.Models.Users
{
    public class BecomeAdminFormModel
    {
        [Required]
        public string PhoneNumber { get; set; }
    }
}
