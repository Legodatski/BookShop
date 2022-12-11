using BookShop.Constants;
using BookShop.Data.Entities;
using BookShop.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Areas.Administration.Models
{
    public class SchoolsViewModel
    {
        public SchoolsViewModel()
        {
            Schools = new HashSet<School>();
            AllSchoolTypes = new HashSet<SchoolTypes>();
            AllTowns = new HashSet<Town>();
        }

        [Required]
        [MaxLength(GlobalConstants.SchoolNameMaxLenght)]
        [MinLength(GlobalConstants.SchoolNameMinLenght)]
        public string Name { get; set; }

        public int TownId { get; set; }

        public IEnumerable<Town> AllTowns { get; set; }

        public SchoolTypes SchoolType { get; set; }

        public IEnumerable<SchoolTypes> AllSchoolTypes { get; set; }

        public IEnumerable<School> Schools { get; set; }
    }
}
