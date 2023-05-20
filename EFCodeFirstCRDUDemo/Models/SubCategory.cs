using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirstCRDUDemo.Models
{
    [Table("SubCategory")]
    public class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }

        [Required]
        [Column("SubCategoryName", TypeName = "varchar(50)")]
        public string Name { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
