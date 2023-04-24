using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using ViewsDemo.Models;

namespace ViewsDemo.Controllers
{
    public class ProductCategoryController : Controller
    {
        string _connectionString = null;
        IConfiguration _configuration;
        public ProductCategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionStrings:B20DemoDB"];
        }

        public IActionResult Index()
        {
            #region Connection oriented architecture

            //SqlConnection con = new SqlConnection(_connectionString);

            //string query = "select * from category;select * from Product";
            //SqlCommand cmd = new SqlCommand(query, con);

            //con.Open();

            //SqlDataReader reader = cmd.ExecuteReader();
            //List<CategoryModel> categories = new List<CategoryModel>();
            //List<ProductViewModel> products = new List<ProductViewModel>();

            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        CategoryModel c = new CategoryModel();
            //        c.CategoryId = (int)reader["CategoryId"];
            //        c.Name = reader["Name"].ToString();
            //        c.Description = reader["Description"].ToString();
            //        categories.Add(c);
            //    }                
            //}

            //reader.NextResult();

            //while (reader.Read())
            //{
            //    products.Add(new ProductViewModel()
            //    {
            //        ProductId = (int)reader["ProductId"],
            //        Name = reader["Name"].ToString(),
            //        UnitPrice = (int)reader["UnitPrice"]
            //    });
            //}

            //con.Close();

            //ProductCategoryModel catProd = new ProductCategoryModel()
            //{
            //    Categories = categories,
            //    Products = products
            //};

            #endregion Connection oriented architecture

            ProductCategoryModel catProd = new ProductCategoryModel();

            SqlConnection con = new SqlConnection(_connectionString);

            string query = "select * from category;select * from Product";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
            {
                catProd.Categories = new List<CategoryModel>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {                    
                    DataRow row = ds.Tables[0].Rows[i];
                    catProd.Categories.Add(
                        new CategoryModel()
                        {
                            Name = row["Name"].ToString(),
                            Description = row["Description"].ToString()
                        });
                }

                catProd.Products = new List<ProductViewModel>();
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {                    
                    DataRow row = ds.Tables[1].Rows[i];
                    catProd.Products.Add(
                        new ProductViewModel()
                        {
                            Name = row["Name"].ToString(),
                            UnitPrice = (int) row["UnitPrice"]
                        });
                }
            }

            return View(catProd);
        }
    }
}
