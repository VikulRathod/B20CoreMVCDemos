using Microsoft.AspNetCore.Mvc;
using MvcTasks.Data;
using MvcTasks.Models;
using System.Security.Cryptography.Xml;

namespace MvcTasks.Controllers
{
    public class CategoryController : Controller
    {
        IConfiguration _config;
        ICategoryDB _db;
        public CategoryController(IConfiguration config, ICategoryDB db)
        {
            _config = config;
            _db = db;
        }

        public IActionResult Index()
        {
            // CategoryDB db = new CategoryDB(_config);
            var categories = _db.Categories();

            return View(categories);
        }

        [HttpGet]
        public IActionResult ProductByCategory(int id, string name)
        {
            // CategoryDB db = new CategoryDB(_config);
            List<Product> products = _db.ProductByCategory(id);

            ViewBag.CategoryName = name;

            return View(products);
        }
    }
}
