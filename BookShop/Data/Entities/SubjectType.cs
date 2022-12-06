
using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Entities
{
    public class SubjectType
    {
        public SubjectType()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; }

    }
}