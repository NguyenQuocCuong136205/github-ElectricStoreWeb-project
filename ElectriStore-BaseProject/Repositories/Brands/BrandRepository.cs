using ElectriStore_BaseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectriStore_BaseProject.Repositories.Brands
{
    public class BrandRepository : IBrandRepository
    {
        ElectronicStoreContext _context;
        public BrandRepository(ElectronicStoreContext electronicStoreContext) {
            this._context = electronicStoreContext;
        }

        public async Task<IEnumerable<Brand>> GetAllBrandsAsync()
        {
            var allBrands = await _context.Brands.ToListAsync();
            return allBrands;
        }

        public async Task<Brand?> GetBrandByIdAsync(int id)
        {
            var brand = await _context.Brands.SingleOrDefaultAsync(b => b.Id == id);
            return brand;
        }
    }
}
