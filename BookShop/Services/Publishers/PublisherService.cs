using BookShop.Data;
using BookShop.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Services.Publishers
{
    public class PublisherService : IPublisherService
    {
        private readonly ApplicationDbContext context;

        public PublisherService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Publisher> GetAllPublishers()
            => context.Publishers.Distinct();

        public async Task<Publisher> GetPublisher(int id)
            => await context.Publishers.FirstOrDefaultAsync(p => p.Id == id);


        public async Task AddPublisher(string name)
        {
            Publisher publisher = new Publisher()
            {
                Name = name
            };

            await context.Publishers.AddAsync(publisher);
            await context.SaveChangesAsync();
        }

        public bool ExistsByName(string name)
            => context.Publishers.Any(p => p.Name == name);
    }
}
