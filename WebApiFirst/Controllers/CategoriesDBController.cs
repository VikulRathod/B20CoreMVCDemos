using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApiFirst.Models;

namespace WebApiFirst.Controllers
{
    // [Route("api/[controller]/[action]")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        AppDbContext _db;
        public CategoriesController(AppDbContext db)
        {
            _db = db;
        }

        // [Produces("application/xml")]
        [HttpGet(Name = "GetCategories")]
        public IActionResult GetCategories(int version = 1)
        {
            if (version == 1)
            {
                var categories = _db.Categories.ToList();
                return Ok(categories);
            }
            else if(version == 2)
            {
                var categories = _db.Categories.Where(c => c.IsActive).ToList();
                return Ok(categories);
            }
            return Ok(null);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Please correct category id");

            Category cat = _db.Categories.Find(id);

            if (cat != null)
            {
                return Ok(cat);
            }

            return NotFound($"{id} category does not exists");
        }

        //[HttpGet(Name = "GetAllAsync")]
        //public async Task<IActionResult> GetAllAsync()
        //{
        //    var categories = await _db.Categories.ToListAsync();
        //    return Ok(categories);
        //}

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost]
        public IActionResult Create(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Category cat = new Category()
                    {
                        Name = category.Name,
                        IsActive = category.IsActive
                    };

                    _db.Categories.Add(cat);
                    _db.SaveChanges();

                    return Created("Create", cat);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        ex.Message);
                }
            }

            return BadRequest("Please check input data");
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut]
        public IActionResult Update(int id, CategoryModel category)
        {
            if (id != category.Id)
                return BadRequest("Please correct category Id");

            if (ModelState.IsValid)
            {
                try
                {
                    Category cat = new Category()
                    {
                        Id = category.Id,
                        Name = category.Name,
                        IsActive = category.IsActive
                    };

                    _db.Categories.Update(cat);
                    _db.SaveChanges();

                    return Ok(cat);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        ex.Message);
                }
            }

            return BadRequest("Please check input data");
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Please correct category Id");

            Category cat = _db.Categories.Find(id);

            if (cat != null)
            {
                try
                {
                    _db.Categories.Remove(cat);
                    _db.SaveChanges();

                    return Ok(cat);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        ex.Message);
                }
            }

            return NotFound($"Category with id {id} does not exists.");
        }
    }
}
