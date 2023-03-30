using AksApp.Data;
using AksApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AksApp.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        string  directoryPath = @"C:\Users\Sahil\source\repos\Aks\AksApp\UserDataFile\";
        private readonly ApplicationDbContext _dbContext;
        public ProductController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            ViewBag.CategoryList = new SelectList(_dbContext.Categories, "CategoryId", "CategoryName");
            IEnumerable<Product> objCategoriesList = _dbContext.Product.ToList();
            ViewData["ProductData"] = objCategoriesList;
            return View();
        }

        public IActionResult Create(DummyProduct dp)
        {
            if(!setDummyProductToPrduct(dp))
            {
                string errMsg = "All Field Required";
                ViewData["fieldnotfilled"] =  errMsg;
            }
            return RedirectToAction("Index");
        }


        public JsonResult GetSubCategoryList(int CategoryId) {
            var subCategory = _dbContext.Subcategories.Where(z => z.CategoryId == CategoryId).ToList();
            var temp = Json(new SelectList(subCategory, "SubCategoryId", "SubCategoryName"));

            return Json(new SelectList(subCategory,"SubCategoryId", "SubCategoryName"));
        }


        private bool setDummyProductToPrduct(DummyProduct dp)
        {
            if (ModelState.IsValid)
            {

            
            string destinationFilePath = Path.Combine(directoryPath, dp.Image.FileName);

            Product product = new Product();
            product.ProductName = dp.ProductName;
            product.ShortDescription = dp.ShortDescription;
            product.CategoryName =_dbContext.Categories.Find(dp.CategoryName).CategoryName;
            product.SubCategoryName = dp.SubCategoryName;
            using (FileStream fileStream = new FileStream(destinationFilePath, FileMode.Create))
            {
                dp.Image.CopyTo(fileStream);
            }
            product.ImagePath = destinationFilePath;

                savePdf(dp.pdf, dp.ProductName);
                saveDescription(dp.Description, dp.ProductName);

 /*               Pdf pdf =  new Pdf(); 
            foreach (var i in dp.pdf)
            {
                destinationFilePath = Path.Combine(directoryPath , i.Files.FileName);
                using (FileStream fileStream = new FileStream(destinationFilePath, FileMode.Create))
                {
                    i.Files.CopyTo(fileStream);
                }
                Pdf pd = new Pdf { heading= i.Heading, pdfPath=destinationFilePath };
                
                product.pdfDb.Add(pd);
            }

*/

 /*           product.Description = new List<UserDescription>();
            foreach(var i in dp.Description)
            {
                UserDescription ud = new UserDescription { Title = i.Title, Heading = i.Heading, description = i.description };
                product.Description.Add(ud);
            }

*/
            product.CkEditorDescription = dp.CkEditorContent;

            product.isActive = dp.isActive;




            SaveProductDataIntoDb(product);

                return true;
            }
            return false;
        }

        private void SaveProductDataIntoDb(Product product)
        {
            _dbContext.Product.Add(product);
            _dbContext.SaveChanges();
        }
        

        private void savePdf(List<ForPdf> pdf, string productName)
        {
            foreach (var i in pdf) {
                string destinationFilePath = Path.Combine(directoryPath, i.Files.FileName);
                using (FileStream fileStream = new FileStream(destinationFilePath, FileMode.Create))
                {
                    i.Files.CopyTo(fileStream);
                }
                Pdf pd = new Pdf { pdfId= productName, heading = i.Heading, pdfPath = destinationFilePath };
                _dbContext.Pdfs.Add(pd);
                _dbContext.SaveChanges();
                _dbContext.Entry(pd).State = EntityState.Detached;

            }
            
        }

        private void saveDescription(List<UserDescription> description, string productName) {
            foreach(var i in description)
            {
                ProductDescription ud = new ProductDescription { Id = productName, Title = i.Title, Heading = i.Heading, description = i.description };
                _dbContext.UserDescription.Add(ud);
                _dbContext.SaveChanges();
                _dbContext.Entry(ud).State = EntityState.Detached;

            }
           
        }



        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var categoryFromDb = _dbContext.Product.Find(id);
            if (categoryFromDb == null)
                return NotFound();
            ViewBag.FromEditAction = true;
            return RedirectToAction("Index", categoryFromDb);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.CategoryName != null)
            {
         //       _db.Categories.Update(obj);
         //       _db.SaveChanges();
                return RedirectToAction("Create");
            }
            return RedirectToAction("Create");
        }






    }
}
