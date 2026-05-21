using Microsoft.AspNetCore.Mvc;
using ElectriStore_BaseProject.Models;
using ElectriStore_BaseProject.Repositories;
using ElectriStore_BaseProject.Repositories.Products;
using ElectriStore_BaseProject.Services.Products;

namespace ElectriStore_BaseProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        IProductService productService;
        public HomeController(IProductService productService) { 
            this.productService = productService;
        }
        public async Task<IActionResult> Index()
        {

            return View();
        }

        //public async Task<IActionResult> ShowProductById()
        //{
        //    int id = 1;
        //    var product = await productRepository.GetProductDTOByIdAsync(id);
        //    return View(product);
        //}
    }
}
