

using BookShop.Core.Models.Books;
using BookShop.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Core.Models.Users
{
    public class DetailsUserModel
    {
        public DetailsUserModel()
        {
            Books = new HashSet<BookViewModel>();
        }

        public string Id { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        [MaxLength(GlobalConstants.FirstNameMaxLenght)]
        [MinLength(GlobalConstants.FirstNameMinLenght)]
        public string FirstName { get; init; } = null!;

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        [MaxLength(GlobalConstants.LastNameMaxLenght)]
        [MinLength(GlobalConstants.LastNameMinLenght)]
        public string LastName { get; init; } = null!;

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        public virtual ICollection<BookViewModel> Books { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string School { get; init; } = "Not given information";
        public string Phone { get; init; } = "Not given information";

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        public string Town { get; init; } = null!;
    }
}
