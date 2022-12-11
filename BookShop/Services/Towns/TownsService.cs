using BookShop.Contracts;
using BookShop.Data;
using BookShop.Data.Entities;
using BookShop.Data.Enums;

namespace BookShop.Services.Towns
{
    public class TownsService : ITownsService
    {
        private readonly ApplicationDbContext context;

        public TownsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddSchool(string name, SchoolTypes type, int townId)
        {
            await context.Schools.AddAsync(new School()
            {
                Name = name,
                SchoolType = type,
                TownId = townId,
                IsDeleted = false,
            });


        }

        public IEnumerable<Town> GetAll()
            => context.Towns
            .Where(town => town.IsDeleted == false)
            .Distinct()
            .ToList();

        public IEnumerable<School> GetAllSchools()
            => context.Schools.Distinct();

        public async Task<Town> GetTownById(int? id)
            => await context.Towns.FindAsync(id);
        public async Task<School> FindSchoolById(int? id)
            => await context.Schools.FindAsync(id);

        public bool ExistsSchoolByName(string name)
            => context.Schools.Any(school => school.Name == name);

        public bool ExistsTownByName(string name)
            => context.Towns.Any(school => school.Name == name);

        public async Task AddTown(string name)
        {
            await context.Towns.AddAsync(new Town() { Name = name, IsDeleted = false });

            await context.SaveChangesAsync();
        }
    }
}
