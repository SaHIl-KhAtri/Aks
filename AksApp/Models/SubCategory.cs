using System.ComponentModel.DataAnnotations;

namespace AksApp.Models
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string Category_Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public bool IsActive { get; set; }
    }
}
