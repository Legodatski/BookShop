using BookShop.Infrastructure.Entities;
using BookShop.Infrastructure.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasOne(f => f.Town)
                .WithMany(f => f.Citizents)
                .OnDelete(DeleteBehavior.Restrict);

            ConfigureIsRequired(builder);

            foreach (var subject in SeedSubjectTypes())
            {
                builder.Entity<SubjectType>()
                    .HasData(subject);
            }

            foreach (var town in SeedTowns())
            {
                builder.Entity<Town>()
                    .HasData(town);
            }

            foreach (var school in SeedSchools())
            {
                builder.Entity<School>()
                    .HasData(school);
            }

            foreach (var publisher in SeedPublishers())
            {
                builder.Entity<Publisher>()
                  .HasData(publisher);
            }

            foreach (var user in SeedUsers())
            {
                builder.Entity<User>()
                  .HasData(user);
            }

            foreach (var book in SeedBooks())
            {
                builder.Entity<Book>()
                    .HasData(book);
            }
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<School> Schools { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<SubjectType> SubjectTypes { get; set; }

        private List<SubjectType> SeedSubjectTypes()
        {
            List<SubjectType> subjectTypes = new List<SubjectType>();

            subjectTypes.Add(new SubjectType() { Id = 1, Name = "Math" });
            subjectTypes.Add(new SubjectType() { Id = 2, Name = "English" });
            subjectTypes.Add(new SubjectType() { Id = 3, Name = "Geography" });
            subjectTypes.Add(new SubjectType() { Id = 4, Name = "Literature" });
            subjectTypes.Add(new SubjectType() { Id = 5, Name = "Programming" });
            subjectTypes.Add(new SubjectType() { Id = 6, Name = "Other" });

            return subjectTypes;
        }

        private List<Town> SeedTowns()
        {
            List<Town> towns = new List<Town>();

            towns.Add(new Town
            {
                Id = 1,
                Name = "Veliko Tarnovo",
                IsDeleted = false
            });
            towns.Add(new Town
            {
                Id = 2,
                Name = "Sofia",
                IsDeleted = false
            });
            towns.Add(new Town
            {
                Id = 3,
                Name = "Varna",
                IsDeleted = false
            });
            towns.Add(new Town
            {
                Id = 4,
                Name = "Other",
                IsDeleted = false
            });

            return towns;
        }

        private List<School> SeedSchools()
        {
            List<School> schools = new List<School>();

            schools.Add(new School
            {
                Id = 1,
                Name = "PMG Vasil Drumev",
                TownId = 1,
                SchoolType = SchoolTypes.HighSchool,
                IsDeleted = false
            });
            schools.Add(new School
            {
                Id = 2,
                Name = "SMG Paisius of Hilendar",
                TownId = 2,
                SchoolType = SchoolTypes.HighSchool,
                IsDeleted = false
            });
            schools.Add(new School
            {
                Id = 3,
                Name = "Anton Strashimirov",
                TownId = 3,
                SchoolType = SchoolTypes.PrimarySchool,
                IsDeleted = false
            });
            schools.Add(new School
            {
                Id = 4,
                Name = "SU Emiliyan Stanev",
                TownId = 1,
                SchoolType = SchoolTypes.MiddleSchool,
                IsDeleted = false
            });
            schools.Add(new School
            {
                Id = 5,
                Name = "Other",
                TownId = 1,
                SchoolType = SchoolTypes.PrimarySchool,
                IsDeleted = false
            });

            return schools;
        }

        private List<Publisher> SeedPublishers()
        {
            List<Publisher> publishers = new List<Publisher>();

            publishers.Add(new Publisher
            {
                Id = 1,
                Name = "Hermes",
                IsDeleted = false
            });
            publishers.Add(new Publisher
            {
                Id = 2,
                Name = "Arhimed",
                IsDeleted = false
            });
            publishers.Add(new Publisher
            {
                Id = 3,
                Name = "Prosveta",
                IsDeleted = false
            });

            return publishers;
        }

        private List<User> SeedUsers()
        {
            List<User> users = new List<User>();

            string hashedGuestPassword = new PasswordHasher<object>().HashPassword(null, "guest123");
            string hashedAdminPassword = new PasswordHasher<object>().HashPassword(null, "admin123");

            users.Add(new User()
            {
                Id = "b68f5083-eb62-49f5-b487-b35c0d5a625c",
                Email = "guest@gmail.com",
                PasswordHash = hashedGuestPassword,
                FirstName = "Pesho",
                LastName = "Peshov",
                PhoneNumber = "0881234567",
                UserName = "PeshoPeshov",
                SchoolId = 1,
                TownId = 1
            });

            users.Add(new User()
            {
                Id = "e97bab0a-4e68-404a-b1d9-57bc8865ab83",
                Email = "admin1@gmail.com",
                PasswordHash = hashedAdminPassword,
                FirstName = "Admin",
                LastName = "Adminov",
                UserName = "AdminAdminov",
                PhoneNumber = "0881234567",
                SchoolId = 1,
                TownId = 1
            });

            return users;
        }

        private List<Book> SeedBooks()
        {
            List<Book> books= new List<Book>();

            books.Add(new Book()
            {
                Id = 10,
                BookTypeId = 5,
                Title = "Coding adventures",
                datePublished = Convert.ToDateTime("05/05/2021"),
                Description = "Learn programming while having fun!",
                Grade = 1,
                OwnerId = "b68f5083-eb62-49f5-b487-b35c0d5a625c",
                ImageUrl = "https://m.media-amazon.com/images/I/51WE1rxr-0L._AC_SY780_.jpg",
                Year = 2020,
                PublisherId = 1,
                Price = 12.50M
            });


            books.Add(new Book()
            {
                Id = 11,
                BookTypeId = 3,
                Title = "Geography",
                datePublished = Convert.ToDateTime("04/10/2022"),
                Description = "Learn the geogrpahy of the whole world.",
                Grade = 7,
                OwnerId = "b68f5083-eb62-49f5-b487-b35c0d5a625c",
                ImageUrl = "https://m.media-amazon.com/images/I/51HiKFBSbFL._AC_SY780_.jpg",
                Year = 2022,
                PublisherId = 2,
                Price = 10.80M
            });

            return books;
        }

        private void ConfigureIsRequired(ModelBuilder builder)
        {
            builder.Entity<User>()
                .Property(f => f.SchoolId)
                .IsRequired(false);
        }
    }
}