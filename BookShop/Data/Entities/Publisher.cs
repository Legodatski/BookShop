using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Entities
{
    public class Publisher
    {
        public Publisher()
        {
            Authors = new HashSet<Author>();
        }

        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(GlobalConstants.PublisherNameMaxLenght)]
        [MinLength(GlobalConstants.PublisherNameMinLenght)]
        public string Name { get; init; } = null!;

        [Required]
        public ICollection<Author> Authors { get; init; }

        public bool IsDeleted { get; set; }
    }
}
