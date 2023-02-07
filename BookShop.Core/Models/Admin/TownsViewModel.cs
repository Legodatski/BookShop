using BookShop.Infrastructure.Constants;
using BookShop.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Core.Models.Admin
{
    public class TownsViewModel
    {
        public TownsViewModel()
        {
            Towns = new HashSet<Town>();
        }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        [MaxLength(GlobalConstants.TownNameMaxLenght)]
        [MinLength(GlobalConstants.TownNameMinLenght)]
        public string Name { get; set; }

        public IEnumerable<Town> Towns { get; set; }
    }
}
