using BookShop.Data;
using BookShop.Data.Entities;

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

        public Publisher GetPublisher(int id)
            => context.Publishers.FirstOrDefault(p => p.Id == id);
    }
}
