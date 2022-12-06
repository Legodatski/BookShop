﻿using BookShop.Data.Entities;
using BookShop.Data.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;
using BookShop.Views.Account.Models;

namespace BookShop.Data
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

            builder.Entity<Book>()
                .Property(b => b.ImageUrl)
                .HasDefaultValue("https://www.google.com/url?sa=i&url=https%3A%2F%2F" +
                "www.freeiconspng.com%2Fimages%2Fno-image-icon&psig=AOvVaw2SB0Epft" +
                "M3utCWoOiGqnSI&ust=1669587243289000&source=images&cd=vfe&ved=0CBAQjRxqFwoTCJj6s6bvzPsCFQAAAAAdAAAAABAJ");

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
                Location = "43.075672, 25.617151",
                IsDeleted = false
            });
            towns.Add(new Town
            {
                Id = 2,
                Name = "Sofia",
                Location = "42.698334, 23.319941",
                IsDeleted = false
            });
            towns.Add(new Town
            {
                Id = 3,
                Name = "Varna",
                Location = "43.204666, 27.910543",
                IsDeleted = false
            });
            towns.Add(new Town
            {
                Id = 4,
                Name = "Other",
                Location = null,
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

        private void ConfigureIsRequired(ModelBuilder builder)
        {
            builder.Entity<Town>()
                .Property(t => t.Location)
                .IsRequired(false);

            builder.Entity<User>()
                .Property(f => f.SchoolId)
                .IsRequired(false);
        }

        public DbSet<BookShop.Views.Account.Models.DetailsUserModel> DetailsUserModel { get; set; }
    }
}