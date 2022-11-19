using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Entities
{
    public class Town
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.TownNameMaxLenght)]
        [MinLength(GlobalConstants.TownNameMinLenght)]
        public string Name { get; set; }

        public string Location { get; set; }
    }
}
