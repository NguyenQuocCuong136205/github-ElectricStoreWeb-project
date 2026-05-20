using ElectriStore_BaseProject.Models;
using ElectriStore_BaseProject.DTOs;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace ElectriStore_BaseProject.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ElectronicStoreContext context;

        public ProductRepository(ElectronicStoreContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var all_products = await context.Products.ToListAsync();
            return all_products;
        }

        // just when add min want to see all attributes
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var book = await context.Products.FindAsync(id);
            return book;
        }

        // use when you want to get some important attribute but dont want to get all atrribute
        public async Task<ProductDisplayDTO?> GetProductDTOByIdAsync(int id)
        {
            var book = await context.Products.FindAsync(id);
            if (book == null) return null;
            return new ProductDisplayDTO(book.Name ?? string.Empty, book.SalePrice ?? 0m, book.StockQuantity ?? 0);
        }
    }
}
