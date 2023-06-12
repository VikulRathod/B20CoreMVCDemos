using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiFirst.Models;

namespace WebApiFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        AppDbContext _db;
        public ProductsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _db.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Please correct product id");

            Product prod = _db.Products.Find(id);

            if (prod != null)
            {
                Category category = _db.Categories.Find(prod.CategoryId);
                if (category != null)
                {
                    prod.Category = new Category()
                    {
                        Id = category.Id,
                        Name = category.Name,
                        IsActive = category.IsActive
                    };
                    return Ok(prod);
                }
            }

            return NotFound($"{id} product does not exists");
        }

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost]
        public IActionResult Create(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Product prod = new Product()
                    {
                        Name = product.Name,
                        UnitPrice = product.UnitPrice,
                        CategoryId = product.CategoryId
                    };

                    _db.Products.Add(prod);
                    _db.SaveChanges();

                    return Created("Create", prod);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        ex.Message);
                }
            }

            return BadRequest("Please check input data");
        }
    }
}
