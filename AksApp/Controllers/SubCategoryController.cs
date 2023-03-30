using AksApp.Data;
using AksApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace AksApp.Controllers
{
    [Authorize]
    public class SubCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }


       
        public ActionResult Create()
        {
            // This code for give the option to user to select Category
            /*     var categories = _context.Categories.Select(c => new SelectListItem
                 {
                     Value = c.CategoryId.ToString(),
                     Text = c.CategoryName
                 });

                 ViewBag.Categories = categories;
                 IEnumerable<SubCategory> objCategoriesList = _context.Subcategories.ToList();

                 ViewData["ModelList"] = objCategoriesList;

                 // Now on this code for print or show the Details of Subcategory 

                 IEnumerable<SubCategory> subCategories = _context.Subcategories.ToList();

                 ViewData["ModelList"] = subCategories;


                 */

            List<SubCategory> subCategoryList = _context.Subcategories.ToList();
            ViewBag.subCategoryList = subCategoryList;
            ViewBag.CategoryList = new SelectList(GetCategoriesList(), "CategoryId", "CategoryName");
            return View();
        }

        public List<Category> GetCategoriesList()
        {
            List<Category> categories = _context.Categories.ToList();
            return categories;
        }

        [HttpPost]
        public ActionResult Create(string selectedCategory, SubCategory subObj)
        {



            SubCategory sbTemp = new SubCategory();
            sbTemp.SubCategoryName = subObj.SubCategoryName;
            sbTemp.CategoryId = subObj.CategoryId;
            sbTemp.Category_Name = _context.Categories.Find(subObj.CategoryId).CategoryName;
            sbTemp.IsActive = subObj.IsActive;

            if(sbTemp.SubCategoryName!=null && sbTemp.Category_Name!=null && sbTemp.CategoryId!=null)
            {
                _context.Subcategories.Add(sbTemp);
                _context.SaveChanges();
                return RedirectToAction("Create");
            }

            /*
            Category temp = new Category();
            if (string.IsNullOrEmpty(selectedCategory))
            {
                ModelState.AddModelError("", "Please select a category.");
                return RedirectToAction("Create");
            }

            int categoryId = int.Parse(selectedCategory);
            

            var category = _context.Categories.Find(categoryId);

            if (category == null)
            {
                ModelState.AddModelError("", "Invalid category selected.");
                return View();
            }

            
            temp.CategoryName = category.CategoryName;
            temp.Subcategories = new List<SubCategory>
            {
                new SubCategory { SubCategoryName = subObj.SubCategoryName, Category_Name=category.CategoryName }
            };

            _context.Categories.Update(temp);
            _context.SaveChanges();
            */
            // Do something with the selected category here

            return RedirectToAction("Create");
        }

        // here writen a code for deleting the Records
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var obj = _context.Subcategories.Find(id);
            if (obj == null)
                return NotFound();
            else
            {
                _context.Subcategories.Remove(obj);
                _context.SaveChanges();
            }
            return RedirectToAction("Create");


        }


        // here i Write a code for Edit the records

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var categoryFromDb = _context.Subcategories.Find(id);
            if (categoryFromDb == null)
                return NotFound();

            return View(categoryFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SubCategory obj)
        {
            if (obj.SubCategoryName!=null && obj.Category_Name!=null)
            {
                _context.Subcategories.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(obj);

            // Do something with the selected category here

            return RedirectToAction("Create");
        }


    }
}
