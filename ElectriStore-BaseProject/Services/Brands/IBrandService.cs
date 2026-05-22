using ElectriStore_BaseProject.DTOs.Brands;
using ElectriStore_BaseProject.Models;

namespace ElectriStore_BaseProject.Services.Brands
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetAllBrandsAsync();

        Task<Brand?> GetBrandByIdAsync(int id);

        Task<Brand?> GetBrandByNameAsync(string name);

        Task<BrandResultDTO> CreateBrandAsync(Brand brand);

        Task<BrandResultDTO> EditBrandAsync(Brand brand);

        Task<BrandResultDTO> DeleteBrandAsync(int id);
    }
}
