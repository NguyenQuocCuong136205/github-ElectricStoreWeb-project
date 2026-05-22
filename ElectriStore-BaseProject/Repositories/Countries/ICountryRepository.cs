using ElectriStore_BaseProject.Models;

namespace ElectriStore_BaseProject.Repositories.Countries
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync();
        Task<Country?> GetCountryByIdAsync(int id);
        Task<Country?> GetCountryByNameAsync(string name);
        Task<bool> CreateCountryAsync(Country country);
        Task<bool> EditCountryAsync(Country country);
        Task<bool> DeleteCountryAsync(int id);
    }
}
