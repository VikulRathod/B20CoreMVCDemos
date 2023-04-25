using MvcTasks.Models;
using System.Data.SqlClient;

namespace MvcTasks.Data
{
    public class CategoryDB : ICategoryDB
    {
        IConfiguration _config;
        string connectionString = null;

        public CategoryDB(IConfiguration config)
        {
            _config = config;
            connectionString = _config["ConnectionStrings:B20CRUDDB"];
        }

        public List<Category> Categories()
        {
            List<Category> categories = new List<Category>();

            SqlConnection con = new SqlConnection(connectionString);
            string query = "select * from Category";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Category model = new Category()
                    {
                        CategoryId = (int)reader["CategoryId"],
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString()
                    };

                    categories.Add(model);
                }
            }

            con.Close();

            return categories;
        }

        public List<Product> ProductByCategory(int? id)
        {
            List<Product> products = new List<Product>();

            SqlConnection con = new SqlConnection(connectionString);
            string query = $"select * from Product where CategoryId = {id}";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product model = new Product()
                    {
                        ProductId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        UnitPrice = reader.GetInt32(2),
                        CategoryId = reader.GetInt32(3)
                    };

                    products.Add(model);
                }
            }

            con.Close();

            return products;
        }
    }
}
