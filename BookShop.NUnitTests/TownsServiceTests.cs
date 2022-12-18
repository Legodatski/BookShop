using BookShop.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace BookShop.NUnitTests
{
    public class TownsServiceTests
    {
        private ApplicationDbContext context;
        private ITownsService townsService;
        private List<Town> towns;
        private List<School> schools;

        [SetUp]
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
                new School(){Id = 10, Name = "SchoolA", SchoolType = SchoolTypes.PrimarySchool, TownId = 1},
                new School(){Id = 20, Name = "SchoolB", SchoolType = SchoolTypes.MiddleSchool, TownId = 2},
                new School(){Id = 30, Name = "SchoolC", SchoolType = SchoolTypes.HighSchool, TownId = 3}
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TownsInMemoryDb")
                .Options;

            context = new ApplicationDbContext(options);

            context.Database.EnsureDeleted();

            context.Towns.AddRange(towns);
            context.Schools.AddRange(schools);
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
        public async Task Test_AddSchool_CorrectInput()
        {
            string schoolName = "SchoolD";
            SchoolTypes type = SchoolTypes.MiddleSchool;

            await townsService.AddSchool(schoolName, type, 1);

            Assert.IsTrue(context.Schools.Any(x=> x.Name == schoolName));
        }

        [Test]
        public async Task Test_AddSchool_InvalidInput()
        {
            Assert.ThrowsAsync<ArgumentException>(() => townsService.AddSchool("a", SchoolTypes.HighSchool, 20));
        }
    }
}
