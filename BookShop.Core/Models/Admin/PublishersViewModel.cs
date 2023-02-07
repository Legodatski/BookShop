using BookShop.Infrastructure.Constants;
using BookShop.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Core.Models.Admin
{
    public class PublishersViewModel
    {
        public PublishersViewModel()
        {
            Publishers = new HashSet<Publisher>();
        }

        [Required(ErrorMessage = GlobalConstants.RequiredErrorMsg)]
        [MaxLength(GlobalConstants.PublisherNameMaxLenght)]
        [MinLength(GlobalConstants.PublisherNameMinLenght)]
        public string Name { get; set; }  

        public IEnumerable<Publisher> Publishers { get; set; }
    }
}
