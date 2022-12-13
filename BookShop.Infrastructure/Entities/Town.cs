using System.ComponentModel.DataAnnotations;
using BookShop.Infrastructure.Constants;

namespace BookShop.Infrastructure.Entities
{
    public class Town
    {
        public Town()
        {
            Citizents = new HashSet<User>();
        }

        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(GlobalConstants.TownNameMaxLenght)]
        [MinLength(GlobalConstants.TownNameMinLenght)]
        public string Name { get; init; } = null!;

        public ICollection<User> Citizents { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}
