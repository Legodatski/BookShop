﻿using BookShop.Data.Entities;

namespace BookShop.Services.Publishers
{
    public interface IPublisherService
    {
        IEnumerable<Publisher> GetAllPublishers();

        Task<Publisher> GetPublisher(int id);

        Task AddPublisher(string name);

        bool ExistsByName(string name);
    }
}
