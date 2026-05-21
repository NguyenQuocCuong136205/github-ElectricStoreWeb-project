using ElectriStore_BaseProject.DTOs;
using ElectriStore_BaseProject.Repositories.Products;

namespace ElectriStore_BaseProject.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductDTORepository _productDTORepository;

        public ProductService(IProductDTORepository productDTORepository)
        {
            _productDTORepository = productDTORepository;
        }

        public async Task<IEnumerable<ProductDisplayDTO>> GetProductDisplayDTOsAsync()
        {
            // Service layer can handle business logic, caching, sorting, or filtering here
            return await _productDTORepository.GetProductsAsync();
        }
    }
}
