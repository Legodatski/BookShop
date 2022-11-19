using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Entities
{
    public class Author
    {
        public Author()
        {
            Publishers = new HashSet<Publisher>();
        }

        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(GlobalConstants.AuthorFirstNameMax)]
        [MinLength(GlobalConstants.AuthorFirstNameMin)]
        public string FirstName { get; init; } = null!;


        [Required]
        [MaxLength(GlobalConstants.AuthorLastNameMax)]
        [MinLength(GlobalConstants.AuthorLastNameMin)]
        public string LastName { get; init; } = null!;

        public ICollection<Publisher> Publishers { get; set; }
    }
}