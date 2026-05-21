using ElectriStore_BaseProject.Models;
using ElectriStore_BaseProject.Repositories.Products;
using Microsoft.EntityFrameworkCore;

namespace ElectriStore_BaseProject.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        ElectronicStoreContext _context;

        public ProductRepository(ElectronicStoreContext electronicStoreContext){
            _context = electronicStoreContext;
        }
        public async Task<IEnumerable<ElectriStore_BaseProject.Models.Product>> GetProductsAsync()
        {
            var allBooks = await _context.Products.ToListAsync();
            return allBooks;
        }

    }
}
