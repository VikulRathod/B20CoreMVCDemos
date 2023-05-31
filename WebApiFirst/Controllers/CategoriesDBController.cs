using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiFirst.Models;

namespace WebApiFirst.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesDBController : ControllerBase
    {
        AppDbContext _db;
        public CategoriesDBController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _db.Categories.ToList();
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();

            return Ok(category);
            // return Created("GetAllCategories", null);
        }
    }
}
