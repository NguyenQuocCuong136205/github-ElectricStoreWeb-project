using ElectriStore_BaseProject.Models;

namespace ElectriStore_BaseProject.Services.Brands
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetAllBrandsAsync();

        Task<Brand?> GetBrandByIdAsync(int id);

        Task<bool> CreateBrandAsync(Brand brand);

        Task<bool> EditBrandAsync(Brand brand);

        Task<bool> DeleteBrandAsync(int id);
    }
}
