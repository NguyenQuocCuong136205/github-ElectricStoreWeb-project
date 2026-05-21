using ElectriStore_BaseProject.Models;

namespace ElectriStore_BaseProject.Repositories.Products
{
    public interface IProductRepository
    {
        Task<IEnumerable<ElectriStore_BaseProject.Models.Product>> GetProductsAsync();
    }
}
