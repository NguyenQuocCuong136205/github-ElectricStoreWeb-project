using ElectriStore_BaseProject.Models;

namespace ElectriStore_BaseProject.Repositories.Brands
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllBrandsAsync();

        Task<Brand?> GetBrandByIdAsync(int id);
    }
}
