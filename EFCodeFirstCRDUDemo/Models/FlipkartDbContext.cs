using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Linq;

namespace EFCodeFirstCRDUDemo.Models
{
    public class FlipkartDbContext : DbContext
    {
        public FlipkartDbContext(DbContextOptions<FlipkartDbContext> options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<Product> Products { get; set; }

        public void InsertCategory(string categoryName, string categoryDescription)
        {
            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "Name",
                    Size = 50,
                    Value = categoryName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "Description",
                    Size = 50,
                    Value = categoryDescription ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                }
            };

            Database?.ExecuteSqlRawAsync("EXEC [dbo].[usp_InsertCategory] @Name, @Description", sqlParameters);
        }
    }
}
