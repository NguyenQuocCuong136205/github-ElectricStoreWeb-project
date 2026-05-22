using ElectriStore_BaseProject.Models;
using ElectriStore_BaseProject.Repositories.Brands;

namespace ElectriStore_BaseProject.Services.Brands
{
    public class BrandService : IBrandService
    {
        IBrandRepository brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public async Task<IEnumerable<Models.Brand>> GetAllBrandsAsync()
        {
            var brands = await brandRepository.GetAllBrandsAsync();
            return brands;
        }

        public async Task<Brand?> GetBrandByIdAsync(int id)
        {
            var brand = await brandRepository.GetBrandByIdAsync(id);
            return brand;
        }

        public async Task<bool> CreateBrandAsync(Brand brand)
        {
            var result = await brandRepository.CreateNewBrand(brand);
            return result;
        }

        public async Task<bool> EditBrandAsync(Brand brand)
        {
            var result = await brandRepository.EditBrand(brand);
            return result;
        }

        public async Task<bool> DeleteBrandAsync(int id)
        {
            var result = await brandRepository.DeleteBrand(id);
            return result;
        }
    }
}
