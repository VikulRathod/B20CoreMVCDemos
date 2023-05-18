using EFDAL;
using EFDAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFDALMVCClient.Controllers
{
    public class CategoriesController : Controller
    {
        FlipkartContext _db;

        public CategoriesController(FlipkartContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var categories = _db.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            try
            {
                _db.Categories.Add(category);
                _db.SaveChanges(); // reflect changes to db
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("Name", "Error in adding category");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                Category cat = _db.Categories.Find(Id);

                _db.Categories.Remove(cat);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {

            }

            return View();
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Category category = _db.Categories.Find(Id);

            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Category category = _db.Categories.Find(Id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            try
            {
                Category existingCategory =
                    _db.Categories.Find(category.CategoryId);

                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch { }

            return View(category);
        }
    }
}
