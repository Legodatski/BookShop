using BookShop.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<School> Schools { get; set; }

        public DbSet<Town> Towns { get; set; }
    }
}