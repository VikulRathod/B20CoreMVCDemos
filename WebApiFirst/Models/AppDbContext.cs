using Microsoft.EntityFrameworkCore;

namespace WebApiFirst.Models
{
    public class AppDbContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public AppDbContext(DbContextOptions<AppDbContext> options) :
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
