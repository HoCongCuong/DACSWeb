using System.ComponentModel.DataAnnotations;

namespace BlogWeb.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
