using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Entities
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

        public string Location { get; init; } = null!;

        public ICollection<User> Citizents { get; set; }

        public bool IsDeleted { get; set; }
    }
}
