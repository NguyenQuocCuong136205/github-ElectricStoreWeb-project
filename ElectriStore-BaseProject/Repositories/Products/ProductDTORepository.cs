using ElectriStore_BaseProject.DTOs;
using ElectriStore_BaseProject.Models;
using ElectriStore_BaseProject.Repositories.Products;
using Microsoft.EntityFrameworkCore;

namespace ElectriStore_BaseProject.Repositories.Product
{
    public class ProductDTORepository : IProductDTORepository
    {
        private readonly ElectronicStoreContext _context;

        public ProductDTORepository(ElectronicStoreContext electronicStoreContext)
        {
            _context = electronicStoreContext;
        }

        public async Task<IEnumerable<ProductDisplayDTO>> GetProductsAsync()
        {
            return await _context.Products
                .Select(p => new ProductDisplayDTO(
                    p.Name ?? "",
                    p.Brand != null ? p.Brand.BrandName ?? "No Brand" : "No Brand",
                    p.Category != null ? p.Category.Name ?? "No Category" : "No Category",
                    p.SalePrice ?? 0,
                    p.StockQuantity ?? 0,
                    p.MadeInNavigation != null ? p.MadeInNavigation.Country1 ?? "Unknown" : "Unknown",
                    p.Rating ?? 0,
                    p.Description ?? "",
                    p.IsActive ?? false
                ))
                .ToListAsync();
        }
    }
}
