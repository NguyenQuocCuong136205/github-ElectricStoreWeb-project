using Microsoft.AspNetCore.Mvc;
using ElectriStore_BaseProject.Models;
using ElectriStore_BaseProject.Repositories;

namespace ElectriStore_BaseProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        IProductRepository productRepository;
        public HomeController(IProductRepository productRepository) { 
            this.productRepository = productRepository;
        }
        public async Task<IActionResult> Index()
        {
            var all_product = await productRepository.GetProductsAsync();
            return View(all_product);
        }

        public async Task<IActionResult> ShowProductById()
        {
            int id = 1;
            var product = await productRepository.GetProductDTOByIdAsync(id);
            return View(product);
        }
    }
}
