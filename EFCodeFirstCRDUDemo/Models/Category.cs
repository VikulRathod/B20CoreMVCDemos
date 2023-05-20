using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirstCRDUDemo.Models
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
