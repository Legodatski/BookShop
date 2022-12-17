using BookShop.Core.Contracts.Admin;
using BookShop.Core.Services.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.NUnitTests
{
    public class AdminServicesTests
    {
        private ApplicationDbContext context;
        private IStatisticsService statisticsService;
        private IAdminService adminService;

        [OneTimeSetUp]
        public void InitializeDb()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "BooksInMemoryDb")
                .Options;

            context = new ApplicationDbContext(options);

            List<User> users = new List<User>()
            {
                new User(){Id = "1", Email = "a@abv.bg", FirstName = "A", LastName = "AA", PhoneNumber = "123"},
                new User(){Id = "2", Email = "b@abv.bg", FirstName = "B", LastName = "BB", PhoneNumber = "456"},
                new User(){Id = "3", Email = "c@abv.bg", FirstName = "C", LastName = "CC", PhoneNumber = "798"}
            };

            context.Users.AddRange(users);

            context.Roles.Add(new IdentityRole() { Id = "971ba58d-3ed5-4950-95b6-5e96a734db6f", Name = "Admin" });

            context.SaveChanges();

            statisticsService = new StatisticsService(context);
            adminService = new AdminService(context);
        }

        [Test]
        public void Test_BookCount()
        {
            Assert.True(statisticsService.BooksCount() == 0);
        }

        [Test]
        public void Test_UsersCount()
        {
            Assert.True(statisticsService.UsersCount() == 3);
        }

        [Test]
        public async Task Test_AddUserToRole()
        {
            await adminService.AddRoleToUser("1");

            Assert.True(context.UserRoles.Any(ru => ru.UserId == "1" && ru.RoleId == "971ba58d-3ed5-4950-95b6-5e96a734db6f"));
        }
    }
}
