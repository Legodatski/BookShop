using BookShop.Core.Contracts;
using BookShop.Infrastructure;
using BookShop.Infrastructure.Entities;
using Ganss.Xss;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Core.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly ApplicationDbContext context;
        private HtmlSanitizer htmlSanitizer;

        public PublisherService(ApplicationDbContext context)
        {
            this.context = context;
            htmlSanitizer = new HtmlSanitizer();
        }

        public IEnumerable<Publisher> GetAllPublishers()
            => context.Publishers.Distinct().Where(x => x.IsDeleted == false);

        public async Task<Publisher> GetPublisher(int id)
        {
            if (!context.Publishers.Any(x => x.Id == id))
            {
                throw new ArgumentException("Invalid Publisher");
            }

            return await context.Publishers.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddPublisher(string name)
        {
            Publisher publisher = new Publisher()
            {
                Name = htmlSanitizer.Sanitize(name)
            };

            await context.Publishers.AddAsync(publisher);
            await context.SaveChangesAsync();
        }

        public bool ExistsByName(string name)
            => context.Publishers.Any(p => p.Name == name);

        public bool ExistsById(int id)
            => context.Publishers.Any(p => p.Id == id);
    }
}
