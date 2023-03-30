using System.ComponentModel.DataAnnotations;

namespace AksApp.Models
{
    public class DummyProduct
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public int CategoryName { get; set; }
        [Required]
        public string SubCategoryName { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public List<ForPdf> pdf { get; set; }
        
       public List<UserDescription> Description { get; set; }

        [Required]

        public string CkEditorContent { get; set; }

        public bool isActive { get; set; }
    }
}
