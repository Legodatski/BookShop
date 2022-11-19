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
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PublisherNameMaxLenght)]
        [MinLength(GlobalConstants.PublisherNameMinLenght)]
        public string Name { get; set; }

        [Required]
        public ICollection<Author> Authors { get; set; } = null!;
    }
}
