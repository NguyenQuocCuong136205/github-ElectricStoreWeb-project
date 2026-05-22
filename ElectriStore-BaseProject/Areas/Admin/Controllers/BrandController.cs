using ElectriStore_BaseProject.Models;
using ElectriStore_BaseProject.Services.Brands;
using Microsoft.AspNetCore.Mvc;

namespace ElectriStore_BaseProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            var brands = await brandService.GetAllBrandsAsync();
            return View(brands);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var brand = await brandService.GetBrandByIdAsync(id);
            return View(brand);
        }

        [HttpPost]
        public async Task<IActionResult> Details(Brand brand)
        {
            if (await brandService.EditBrandAsync(brand))
            {
                TempData["SuccessMessage"] = "Thay đôi thương hiệu thành công!";
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            else
            {
                TempData["ErrorMessage"] = "Thay đổi thương hiệu thất bại!";
                return View(brand);
            }
            return View();
        }
    }
}
