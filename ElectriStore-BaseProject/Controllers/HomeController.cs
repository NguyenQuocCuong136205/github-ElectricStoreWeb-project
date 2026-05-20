using ElectriStore_BaseProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ElectriStore_BaseProject.Controllers
{
    public class HomeController : Controller
    {
        ElectronicStoreContext db = new ElectronicStoreContext();
        public IActionResult Index()
        {
            var all_product = db.Products.ToList();
            return View(all_product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
