using ElectriStore_BaseProject.DTOs;

namespace ElectriStore_BaseProject.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDisplayDTO>> GetProductDisplayDTOsAsync();
    }
}
