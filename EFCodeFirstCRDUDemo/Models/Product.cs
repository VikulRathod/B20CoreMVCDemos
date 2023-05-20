using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirstCRDUDemo.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        private string _country;

        
        public string Country
        {
            get { return _country; }
            set
            {
                if (value == "INDIA")
                {
                    _country = value;
                }
            }
        }

        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
