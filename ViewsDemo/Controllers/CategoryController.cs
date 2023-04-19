using Microsoft.AspNetCore.Mvc;
using ViewsDemo.Models;

namespace ViewsDemo.Controllers
{
    public class CategoryController : Controller
    {
        // to show list of cateogries
        public IActionResult Index()
        {
            List<CategoryModel> categories = new List<CategoryModel>() 
            {
            new CategoryModel(){Name = "Shirt", Description ="Casual Shirts"},
            new CategoryModel(){Name = "Shoes", Description ="Sports Shoes"}
            };

            return View(categories);
        }

        // to show details of category by id
        public IActionResult Details(int? id)
        {
            return View();
        }

        // to provide form to create a new category
        public IActionResult Create()
        {
            return View();
        }

        // to edit any category by its id
        public IActionResult Edit(int? id)
        {
            return View();
        }

        // to delete category by its id
        public IActionResult Delete(int? id)
        {
            return View();
        }
    }
}
