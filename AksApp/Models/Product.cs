using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AksApp.Models
{
 
    public class Product
    {
      

        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string SubCategoryName { get; set; }
        [Required]
        public string ImagePath { get; set; }
 
       [Required]
       public string CkEditorDescription { get; set; }

        public bool isActive { get; set; }
        
    }


}
