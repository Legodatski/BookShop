using BookShop.Constants;
using BookShop.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Areas.Administration.Models
{
    public class PublishersViewModel
    {
        public PublishersViewModel()
        {
            Publishers = new HashSet<Publisher>();
        }

        [Required]
        [MaxLength(GlobalConstants.PublisherNameMaxLenght)]
        [MinLength(GlobalConstants.PublisherNameMinLenght)]
        public string Name { get; set; }  

        public IEnumerable<Publisher> Publishers { get; set; }
    }
}
