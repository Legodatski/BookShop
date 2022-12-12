using BookShop.Data.Entities;
using BookShop.Views.Books.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using BookShop.Constants;

namespace BookShop.Views.Account.Models
{
    public class DetailsUserModel
    {
        public DetailsUserModel()
        {
            Books = new HashSet<BookViewModel>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.FirstNameMaxLenght)]
        [MinLength(GlobalConstants.FirstNameMinLenght)]
        public string FirstName { get; init; } = null!;

        [Required]
        [MaxLength(GlobalConstants.LastNameMaxLenght)]
        [MinLength(GlobalConstants.LastNameMinLenght)]
        public string LastName { get; init; } = null!;

        [Required]
        public virtual ICollection<BookViewModel> Books { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string School { get; init; } = "Not given information";
        public string Phone { get; init; } = "Not given information";

        [Required]
        public string Town { get; init; } = null!;
    }
}
