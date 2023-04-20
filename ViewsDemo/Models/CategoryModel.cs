using System.ComponentModel;

namespace ViewsDemo.Models
{
    public class CategoryModel
    {
        [DisplayName("Category Id")]
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
