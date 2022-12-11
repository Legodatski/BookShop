using System.ComponentModel.DataAnnotations;

namespace BookShop.Views.Account.Models
{
    public class BecomeAdminFormModel
    {
        [Required]
        public string PhoneNumber { get; set; }
    }
}
