using BookShop.Core.Contracts;
using BookShop.Infrastructure;
using BookShop.Infrastructure.Entities;
using BookShop.Infrastructure.Enums;

namespace BookShop.Core.Services
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
            => context.Schools.Distinct().Where(x => x.IsDeleted == false);

        public async Task<Town> GetTownById(int? id)
        {
            var Town = await context.Towns.FindAsync(id);

            if (Town == null)
            {
                throw new ArgumentNullException();
            }

            return Town;
        }

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

        public bool ExistsSchoolById(int id)
            => context.Schools.Any(school => school.Id == id);

        public bool ExistsTownById(int id)
            => context.Towns.Any(school => school.Id == id);
    }
}
