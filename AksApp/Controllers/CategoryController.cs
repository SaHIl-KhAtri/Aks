using AksApp.Data;
using AksApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AksApp.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        public readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Create()
        {

            IEnumerable<Category> objCategoriesList = _db.Categories.ToList();

            ViewData["ModelList"] = objCategoriesList;
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.CategoryName!=null && obj.IsActive!=null)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                IEnumerable<Category> objCategoriesList = _db.Categories.ToList();
                ViewData["ModelList"] = objCategoriesList;
                return View();
            }
            return View(obj);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
                return NotFound();

            return View(categoryFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.CategoryName!=null)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Create");
            }
            return RedirectToAction("Create");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var obj = _db.Categories.Find(id);
            if (obj == null)
                return NotFound();
            else
            {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("Create");
        }
 /*       [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
 */


    }
}
