using BookShop.Data;
using BookShop.Data.Entities;

namespace BookShop.Services.Towns
{
    public interface ITownsService
    {
        IEnumerable<Town> GetAll();
    }
}
