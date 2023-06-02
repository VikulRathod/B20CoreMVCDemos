//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace WebApiFirst.Controllers
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class CategoriesController : ControllerBase
//    {
//        private Dictionary<int, string> categories =
//            new Dictionary<int, string>();

//        public CategoriesController()
//        {
//            categories.Add(1, "Men");
//            categories.Add(2, "Kids");
//            categories.Add(3, "Women");
//        }

//        // domain/categories = GET
//        [HttpGet(Name = "GetAllCategories")]
//        public List<string> GetAllCategories()
//        {
//            return new List<string>() { "Men", "Kids", "Women" };
//        }

//        // domain/categories/1 = GET
//        [HttpGet("{id}", Name = "GetCategoryById")]
//        public string GetById(int? id)
//        {
//            return categories[id ?? 1];
//        }

//        [HttpPost]
//        public void Create(string category)
//        {

//        }

//        [HttpPut]
//        public void Update(int id, string category)
//        {

//        }

//        [HttpDelete]
//        public void Delete(int id)
//        {

//        }
//    }
//}
