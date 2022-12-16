using BookShop.Core.Services;
using BookShop.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.NUnitTests
{
    public class PublisherServiceTests
    {
        private ApplicationDbContext context;
        private IPublisherService publisherService;
        private List<Publisher> publishers;

        [OneTimeSetUp]
        public void InitializeDb()
        {
            publishers = new List<Publisher>()
            {
                new Publisher() { Id = 1, Name = "PublisherA", IsDeleted = false },
                new Publisher() { Id = 2, Name = "PublisherB", IsDeleted = false },
                new Publisher() { Id = 3, Name = "PublisherC", IsDeleted = false }
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "PublishersInMemoryDb")
                .Options;

            context = new ApplicationDbContext(options);
            context.AddRange(publishers);
            context.SaveChanges();

            publisherService = new PublisherService(context);
        }

        [Test]
        public void Test_GetAllPublishers()
        {
            List<Publisher> actualPublishers = publisherService.GetAllPublishers().ToList();

            if (publishers.Count != actualPublishers.Count())
            {
                Assert.Fail();
            }

            for (int i = 0; i < actualPublishers.Count(); i++)
            {
                if (!actualPublishers[i].Equals(publishers[i]))
                {
                    Assert.Fail();
                }
            }

            Assert.Pass();
        }

        [Test]
        public async Task Test_GetPublisher_CorrectInput()
        {
            int id = 1;

            var expectedPublisher = context.Publishers.Find(id);

            Assert.True(expectedPublisher.Equals(await publisherService.GetPublisher(id)));
        }

        [Test]
        public async Task Test_GetPublisher_InvalidInput()
        {
            Assert.ThrowsAsync<ArgumentException>(() => publisherService.GetPublisher(100));
        }

        [Test]
        public void Test_ExistsByName_CorrectInput()
        {
            Assert.True(publisherService.ExistsByName("PublisherB"));
        }

        [Test]
        public void Test_ExistsByName_InvaidInput()
        {
            Assert.False(publisherService.ExistsByName("PublisherW"));
        }

        [Test]
        public void Test_ExistsById_CorrectInput()
        {
            Assert.True(publisherService.ExistsById(1));
        }

        [Test]
        public void Test_ExistsById_InvaidInput()
        {
            Assert.False(publisherService.ExistsById(100));
        }

        [Test]
        public async Task Test_AddPublisher_CorrectInput()
        {
            string name = "PublisherD";
            
            await publisherService.AddPublisher(name);

            Assert.True(context.Publishers.Any(x => x.Name == name));
        }
    }
}