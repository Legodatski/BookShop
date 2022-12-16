using BookShop.Core.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace BookShop.NUnitTests
{
    public class UserServicesTests
    {
        private ApplicationDbContext context;
        private IUserService userService;

        [OneTimeSetUp]
        public void InitializeDb()
        {
            List<User> users = new List<User>()
            {
                new User(){Id = "1", Email = "a@abv.bg", FirstName = "A", LastName = "AA", PhoneNumber = "123"},
                new User(){Id = "2", Email = "b@abv.bg", FirstName = "B", LastName = "BB", PhoneNumber = "456"},
                new User(){Id = "3", Email = "c@abv.bg", FirstName = "C", LastName = "CC", PhoneNumber = "798"}
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "UsersInMemoryDb")
                .Options;

            context = new ApplicationDbContext(options);
            context.AddRange(users);
            context.SaveChanges();

            userService = new UserService(context);
        }

        [Test]
        public void Test_ExistById_CorrectInput()
        {
            bool result = userService.ExistsById("1");

            Assert.True(result);
        }

        [Test]
        public void Test_ExistById_IvalidInput()
        {
            Assert.AreEqual(userService.ExistsById("10"), false);
        }

        [Test]
        public void Test_EditUser_CorrectInput()
        {
            string userId = "1";

            EditUserModel model = new EditUserModel()
            {
                Email = "a1@gmail.com",
                FirstName = "a1",
                LastName = "a2",
                PhoneNumber = "987",
                SchoolId = 3,
                TownId = 3
            };

            userService.EditUser(model, userId);

            User expetctedUser = context.Users.Find(userId);

            bool result =
                expetctedUser.FirstName == model.FirstName &&
                expetctedUser.LastName == model.LastName &&
                expetctedUser.PhoneNumber == model.PhoneNumber &&
                expetctedUser.Email == model.Email &&
                expetctedUser.SchoolId == model.SchoolId &&
                expetctedUser.TownId == model.TownId;

            Assert.IsTrue(result);
        }

        [Test]
        public async Task Test_EditUser_InvalidInput()
        {
            EditUserModel model = new EditUserModel();

            Assert.ThrowsAsync<ArgumentNullException>(() => userService.EditUser(model, "100"));
        }

        [Test]
        public async Task Test_FindById_CorrectInput()
        {
            var user = await userService.FindById("2");

            User expcetedUser =
                new User() { Id = "2", Email = "b@abv.bg", FirstName = "B", LastName = "BB", PhoneNumber = "456" };

            Assert.IsTrue(CompareUsers(expcetedUser, user));
        }

        [Test]
        public async Task Test_FindById_InvalidInput()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => userService.FindById("10"));
        }


        private bool CompareUsers(User userOne, User userTwo)
        {
            return
                userOne.FirstName == userTwo.FirstName &&
                userOne.LastName == userTwo.LastName &&
                userOne.PhoneNumber == userTwo.PhoneNumber &&
                userOne.Email == userTwo.Email &&
                userOne.SchoolId == userTwo.SchoolId &&
                userOne.TownId == userTwo.TownId;

        }
    }
}