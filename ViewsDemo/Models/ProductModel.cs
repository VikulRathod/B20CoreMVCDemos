using System.ComponentModel;

namespace ViewsDemo.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public int Price { get; set; }

        [DisplayName("Category")]
        public string CategoryName { get; set; }
    }
}
