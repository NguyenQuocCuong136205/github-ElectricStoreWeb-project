using ElectriStore_BaseProject.DTOs;

namespace ElectriStore_BaseProject.Repositories.Products
{
    public interface IProductDTORepository
    {
        Task<IEnumerable<ProductDisplayDTO>> GetProductsAsync();
    }
}
