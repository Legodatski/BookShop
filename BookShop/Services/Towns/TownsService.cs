using BookShop.Data;
using BookShop.Data.Entities;

namespace BookShop.Services.Towns
{
    public class TownsService : ITownsService
    {
        private readonly ApplicationDbContext context;

        public TownsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Town> GetAll()
            => context.Towns
            .Where(town => town.IsDeleted == false)
            .Distinct()
            .ToList();

    }
}
