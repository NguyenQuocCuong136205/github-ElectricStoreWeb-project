using Microsoft.AspNetCore.Mvc;

namespace ElectriStore_BaseProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SupplierController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
