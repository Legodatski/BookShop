using BookShop.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookShop.NUnitTests
{
    public class TownsServiceTests
    {
        private ApplicationDbContext context;
        private ITownsService townsService;
        private List<Town> towns;
        private List<School> schools;

        [OneTimeSetUp]
        public void InitializeDb()
        {
            towns = new List<Town>()
            {
                new Town(){Id = 1, Name = "Veliko Tarnovo", IsDeleted = false},
                new Town(){Id = 2, Name = "Sofia", IsDeleted = false},
                new Town(){Id = 3, Name = "Plovidic", IsDeleted = false},
            };

            schools = new List<School>()
            {
                new School(){Id = 1, Name = "SchoolA", SchoolType = SchoolTypes.HighSchool, TownId = 1, IsDeleted = false},
                new School(){Id = 2, Name = "SchoolB", SchoolType = SchoolTypes.PrimarySchool, TownId = 2, IsDeleted = false},
                new School(){Id = 3, Name = "SchoolC", SchoolType = SchoolTypes.MiddleSchool, TownId = 3, IsDeleted = false},
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TownsInMemoryDb")
                .Options;

            context = new ApplicationDbContext(options);
            context.AddRange(towns);
            context.SaveChanges();

            townsService = new TownsService(context);
        }

        [Test]
        public void Test_GetAllTowns()
        {
            List<Town> actualTowns = townsService.GetAll().ToList();

            if (towns.Count() != actualTowns.Count())
            {
                Assert.Fail();
            }

            for (int i = 0; i < actualTowns.Count(); i++)
            {
                if (!actualTowns[i].Equals(towns[i]))
                {
                    Assert.Fail();
                }
            }

            Assert.Pass();
        }

        [Test]
        public async Task Test_GetTownById_CorrectInput()
        {
            var expectedTown = new Town() { Id = 1, Name = "Veliko Tarnovo", IsDeleted = false };
            var actualTown = await townsService.GetTownById(expectedTown.Id);

            bool result =
                expectedTown.Name == actualTown.Name &&
                expectedTown.Id == actualTown.Id &&
                expectedTown.IsDeleted == actualTown.IsDeleted;

            Assert.True(result);
        }

        [Test]
        public async Task Test_GetTownById_InvalidInput()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => townsService.GetTownById(10));
        }

        [Test]
        public void Test_ExistsTownById()
        {
            Assert.That(townsService.ExistsTownById(1));
        }

        [Test]
        public void Test_ExistsTownByName()
        {
            Assert.That(townsService.ExistsTownByName("Sofia"));
        }

        [Test]
        public void Test_AddTown()
        {
            string townName = "Gorna Orqhovica";
            townsService.AddTown(townName);

            Assert.That(context.Towns.FirstOrDefault(x => x.Name == townName) != null);
        }

        [Test]
    }
}
