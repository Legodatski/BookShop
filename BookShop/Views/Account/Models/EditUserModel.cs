using BookShop.Data.Entities;

namespace BookShop.Views.Account.Models
{
    public class EditUserModel
    {
        public EditUserModel()
        {
            Schools = new HashSet<School>();
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int SchoolId { get; set; }

        public IEnumerable<School> Schools { get; set; }

        public int TownId { get; set; }

        public IEnumerable<Town> Towns { get; set; }
    }
}
