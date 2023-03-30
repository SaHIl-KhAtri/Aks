using AksApp.Data;
using AksApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AksApp.Controllers
{
    [Authorize]
    public class ChangePasswordController : Controller
    {
        public ApplicationDbContext _db;

        public ChangePasswordController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ChangePassword obj)
        {
            
            if (ModelState.IsValid)
            {
                if (obj.oldPassWord == _db.userCredentials.Find(2).Password)
                {
                    if(obj.newPassWord == obj.confirmPassWord)
                    {
                        var entity = _db.userCredentials.SingleOrDefault(x => x.Id == 2);
                        entity.Password = obj.newPassWord;
                        _db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        string errorMsg = "Both New Password And OldPassWord Should Be Same";
                        TempData["ErrorMessage"] = errorMsg;
                        return View(obj);
                    }

                }
                else
                {
                    string errorMsg1 = "Invalid Current Password";
                    TempData["ErrorMessage"] = errorMsg1;
                    return View(obj);
                }
            }
            string errorMsg2 = "Pleas Enter Valid Input";
            TempData["ErrorMessage"] = errorMsg2;
            return View(obj);
        }
    }
}
