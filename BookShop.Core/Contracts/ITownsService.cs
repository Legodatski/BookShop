using BookShop.Infrastructure.Entities;
using BookShop.Infrastructure.Enums;

namespace BookShop.Core.Contracts
{
    public interface ITownsService
    {
        IEnumerable<Town> GetAll();

        Task<Town> GetTownById(int? id);

        IEnumerable<School> GetAllSchools();

        Task AddSchool(string name, SchoolTypes type, int townId);
        Task<School> FindSchoolById(int? id);

        bool ExistsSchoolByName(string name);

        bool ExistsTownByName(string name);
        bool ExistsSchoolById(int id);
        bool ExistsTownById(int id);

        Task AddTown(string name);
    }
}
