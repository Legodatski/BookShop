using BookShop.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Data.Entities
{
    public class School
    {
        public School()
        {
            Students = new HashSet<User>();
        }

        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(GlobalConstants.SchoolNameMaxLenght)]
        [MinLength(GlobalConstants.SchoolNameMinLenght)]
        public string Name { get; init; } = null!;

        [Required]
        public Town Town { get; init; } = null!;

        [ForeignKey(nameof(Town))]
        public int TownId { get; init; }

        [Required]
        public SchoolTypes SchoolType { get; init; }

        public ICollection<User> Students { get; init; }

        public bool IsDeleted { get; set; }
    }
}