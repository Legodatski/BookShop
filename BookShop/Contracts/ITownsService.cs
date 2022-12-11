using BookShop.Data;
using BookShop.Data.Entities;
using BookShop.Data.Enums;

namespace BookShop.Contracts
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

        Task AddTown(string name);
    }
}
