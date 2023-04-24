using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using ViewsDemo.Models;

namespace ViewsDemo.Controllers
{
    public class ProductsController : Controller
    {
        IConfiguration _config;
        public ProductsController(IConfiguration config)
        {
            _config = config;
        }

        // list of product from db show on view
        public IActionResult Index()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();

            // we want to fetch all products from product table
            // string connectionString = "Server=.\\sqlexpress;database=B20DemoDB;Integrated Security=True";

            string connectionString = _config["ConnectionStrings:B20DemoDB"];
            SqlConnection connection = new SqlConnection(connectionString);
            // connection.ConnectionString = connectionString;

            SqlCommand cmd = new SqlCommand("select * from product", connection);
            //cmd.CommandText = "select * from product";
            //cmd.Connection = connection;

            connection.Open(); // to open connection

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ProductViewModel p = new ProductViewModel();
                    p.ProductId = (int)reader["ProductId"];
                    p.Name = reader["Name"].ToString();
                    p.UnitPrice = (int)reader["UnitPrice"];

                    products.Add(p);
                }
            }

            connection.Close();

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel product)
        {
            #region inline query
            //string connectionString =
            //    "server=.\\sqlexpress;database=B20DemoDB;integrated security=true;";

            //SqlConnection connection = new SqlConnection(connectionString);
            //connection.Open();

            //string cmdText = $"insert into Product values ('{product.Name}', {product.UnitPrice})";
            //SqlCommand cmd = new SqlCommand(cmdText, connection);

            //int rows = cmd.ExecuteNonQuery();
            //if(rows > 0)
            //{
            //    return RedirectToAction("Index");
            //}

            #endregion inline query

            #region stored procedure

            //string connectionString =
            //    "server=.\\sqlexpress;database=B20DemoDB;integrated security=true;";

            string connectionString = _config["ConnectionStrings:B20DemoDB"];

            SqlConnection connection = new SqlConnection(connectionString);
            

            // string cmdText = $"insert into Product values ('{product.Name}', {product.UnitPrice})";

            string cmdText = "usp_InsertProduct";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Price", product.UnitPrice);

            SqlParameter status = new SqlParameter()
            {
                ParameterName = "@Status",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(status);

            connection.Open();

            int rows = cmd.ExecuteNonQuery();

            connection.Close();

            if ((bool)status.Value)
            {
                return RedirectToAction("Index");
            }

            #endregion stored procedure

            return View();
        }
    }
}
