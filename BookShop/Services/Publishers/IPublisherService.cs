using BookShop.Data.Entities;

namespace BookShop.Services.Publishers
{
    public interface IPublisherService
    {
        IEnumerable<Publisher> GetAllPublishers();

        Publisher GetPublisher(int id);
    }
}
