using ElectriStore_BaseProject.Models;
using ElectriStore_BaseProject.DTOs;
using Microsoft.AspNetCore;

namespace ElectriStore_BaseProject.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        // just when add min want to see all attributes
        Task<Product?> GetProductByIdAsync(int id);

        // use when you want to get some important attribute but dont want to get all atrribute
        Task<ProductDisplayDTO?> GetProductDTOByIdAsync(int id);
    }
}
