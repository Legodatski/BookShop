﻿using BookShop.Data.Entities;

namespace BookShop.Contracts
{
    public interface IPublisherService
    {
        IEnumerable<Publisher> GetAllPublishers();

        Task<Publisher> GetPublisher(int id);

        Task AddPublisher(string name);

        bool ExistsByName(string name);
        bool ExistsById(int id);
    }
}
