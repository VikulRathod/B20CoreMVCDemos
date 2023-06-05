using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiFirst.Models;

namespace WebApiFirst.Controllers
{
    // [Route("api/[controller]")]
    [Route("api/v2/categories")]
    [ApiController]
    public class CategoriesV2Controller : ControllerBase
    {
        AppDbContext _db;
        public CategoriesV2Controller(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet(Name = "GetAll")]
        public IActionResult GetCategories(string type)
        {
            bool expType;
            List<Category> categories = null;
            bool isValidType = bool.TryParse(type, out expType);

            if (!string.IsNullOrEmpty(type) && !isValidType)
            {
                categories = _db.Categories.ToList();
            }
            else
            {
                categories = _db.Categories.Where(c => c.IsActive == expType).ToList();
            }

            // var categories = _db.Categories.ToList();
            return Ok(categories);
        }
    }
}
