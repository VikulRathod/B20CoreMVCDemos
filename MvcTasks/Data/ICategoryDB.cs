using MvcTasks.Models;

namespace MvcTasks.Data
{
    public interface ICategoryDB
    {
        List<Category> Categories();
        List<Product> ProductByCategory(int? id);
    }
}
