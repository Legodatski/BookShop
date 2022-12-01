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
    }
}
