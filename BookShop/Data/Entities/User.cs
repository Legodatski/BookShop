using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Data.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            Books = new HashSet<Book>();
        }

        [Required]
        [MaxLength(GlobalConstants.FirstNameMaxLenght)]
        [MinLength(GlobalConstants.FirstNameMinLenght)]
        public string FirstName { get; init; } = null!;

        [Required]
        [MaxLength(GlobalConstants.LastNameMaxLenght)]
        [MinLength(GlobalConstants.LastNameMinLenght)]
        public string LastName { get; init; } = null!;
         
        [Required]
        public virtual ICollection<Book> Books { get; init; }

        public School School { get; init; } = null!;

        [Required]
        public Town Town { get; init; } = null!;


        [ForeignKey(nameof(Town))]
        public int? TownId { get; init; }
    }
}
