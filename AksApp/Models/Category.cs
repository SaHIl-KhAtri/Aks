using System.ComponentModel.DataAnnotations;

namespace AksApp.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public List<SubCategory> Subcategories { get; set; }

        public bool IsActive { get; set; }
    }
}
