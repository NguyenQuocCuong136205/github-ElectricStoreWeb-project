using ElectriStore_BaseProject.DTOs.Countries;
using ElectriStore_BaseProject.Models;

namespace ElectriStore_BaseProject.Services.Countries
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync();
        Task<Country?> GetCountryByIdAsync(int id);
        Task<CountryResultDTO> CreateCountryAsync(Country country);
        Task<CountryResultDTO> EditCountryAsync(Country country);
        Task<CountryResultDTO> DeleteCountryAsync(int id);
    }
}
