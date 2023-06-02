using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiClient.Models
{
    public class CategoryModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }

        [JsonPropertyName("isActive")]
        [Required]
        public bool IsActive { get; set; }

        // public ICollection<ProductModel> Products { get; set; }
    }
}
