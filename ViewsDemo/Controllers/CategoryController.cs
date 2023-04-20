using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using ViewsDemo.Models;

namespace ViewsDemo.Controllers
{
    public class CategoryController : Controller
    {
        // to show list of cateogries
        public IActionResult Index()
        {
            //List<CategoryModel> categories = new List<CategoryModel>() 
            //{
            //new CategoryModel(){CategoryId = 1, Name = "Shirt", Description ="Casual Shirts"},
            //new CategoryModel(){CategoryId = 2, Name = "Shoes", Description ="Sports Shoes"}
            //};

            List<CategoryModel> categories = new List<CategoryModel>();

            string cs =
                "server=.\\sqlexpress;database=B20DemoDB;integrated security=true;";
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Category";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CategoryModel model = new CategoryModel()
                    {
                        CategoryId = (int)reader["CategoryId"],
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString()
                    };

                    categories.Add(model);
                }
            }

            con.Close();

            return View(categories);
        }

        // to show details of category by id
        public IActionResult Details(int? id)
        {
            //List<CategoryModel> categories = new List<CategoryModel>()
            //{
            //new CategoryModel(){CategoryId = 1, Name = "Shirt", Description ="Casual Shirts"},
            //new CategoryModel(){CategoryId = 2, Name = "Shoes", Description ="Sports Shoes"}
            //};

            //CategoryModel model =
            //    categories.Where(c => c.CategoryId == id).FirstOrDefault();

            string cs =
                "server=.\\sqlexpress;database=B20DemoDB;integrated security=true;";
            SqlConnection con = new SqlConnection(cs);
            string query = $"select * from Category where CategoryId = {id}";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            CategoryModel model = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    model = new CategoryModel()
                    {
                        CategoryId = (int)reader["CategoryId"],
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString()
                    };
                    break;
                }
            }

            con.Close();

            return View(model);
        }

        // to provide form to create a new category
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //public IActionResult Create(string Name, string Description)
        public IActionResult Create(CategoryModel category)
        // public IActionResult Create(IFormCollection form)
        {
            //string name = form["Name"];
            //string description = form["Description"];

            string cs =
                "server=.\\sqlexpress;database=B20DemoDB;integrated security=true;";
            SqlConnection con = new SqlConnection(cs);
            string query = $"insert into Category values ('{category.Name}', '{category.Description}')";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            int records = cmd.ExecuteNonQuery();
            if (records > 0)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // to edit any category by its id
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //List<CategoryModel> categories = new List<CategoryModel>()
            //{
            //new CategoryModel(){CategoryId = 1, Name = "Shirt", Description ="Casual Shirts"},
            //new CategoryModel(){CategoryId = 2, Name = "Shoes", Description ="Sports Shoes"}
            //};

            //CategoryModel model =
            //    categories.Where(c => c.CategoryId == id).FirstOrDefault();

            string cs =
                "server=.\\sqlexpress;database=B20DemoDB;integrated security=true;";
            SqlConnection con = new SqlConnection(cs);
            string query = $"select * from Category where CategoryId = {id}";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            CategoryModel model = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    model = new CategoryModel()
                    {
                        CategoryId = (int)reader["CategoryId"],
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString()
                    };
                    break;
                }
            }

            con.Close();

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CategoryModel model)
        {
            string cs =
                "server=.\\sqlexpress;database=B20DemoDB;integrated security=true;";
            SqlConnection con = new SqlConnection(cs);
            string query =
                $"update Category set Name = '{model.Name}', Description = '{model.Description}' where CategoryId = " + model.CategoryId;

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            int records = cmd.ExecuteNonQuery();
            if (records > 0)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // to delete category by its id
        [HttpGet]
        [ActionName("Delete")]
        public IActionResult Delete_Get(int? id)
        {
            //List<CategoryModel> categories = new List<CategoryModel>()
            //{
            //new CategoryModel(){CategoryId = 1, Name = "Shirt", Description ="Casual Shirts"},
            //new CategoryModel(){CategoryId = 2, Name = "Shoes", Description ="Sports Shoes"}
            //};

            //CategoryModel model =
            //    categories.Where(c => c.CategoryId == id).FirstOrDefault();

            string cs =
                "server=.\\sqlexpress;database=B20DemoDB;integrated security=true;";
            SqlConnection con = new SqlConnection(cs);
            string query = $"select * from Category where CategoryId = {id}";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            CategoryModel model = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    model = new CategoryModel()
                    {
                        CategoryId = (int)reader["CategoryId"],
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString()
                    };
                    break;
                }
            }

            con.Close();

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete_Confirmed(int? id)
        {
            string cs =
                "server=.\\sqlexpress;database=B20DemoDB;integrated security=true;";
            SqlConnection con = new SqlConnection(cs);
            string query = $"delete from Category where CategoryId = {id}";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            int records = cmd.ExecuteNonQuery();
            if (records > 0)
            {
                return RedirectToAction("Index");
            }

            con.Close();

            return View();
        }
    }
}
