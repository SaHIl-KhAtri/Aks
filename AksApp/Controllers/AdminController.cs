using AksApp.Data;
using AksApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AksApp.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        /*       public readonly ApplicationDbContext _db;

               public AdminController(ApplicationDbContext db)
               {
                   _db = db;
               }


               [HttpPost]
               public ActionResult CheakCredential(UserCredentials crd)
               {
                   // Process the form data here
                   if(ModelState.IsValid)
                   {
                       var objCredententialList = _db.userCredentials.Find(2);
                       if(objCredententialList.Email== crd.Email && objCredententialList.Email!=null)
                       {
                           if(objCredententialList.Password== crd.Password && objCredententialList.Password!=null) {
                             return RedirectToAction("admin");
                           }
                       }
                       else
                       {
                           string errorMsg = "Your credentials are invalid. Please try again.";
                           TempData["ErrorMessage"] = errorMsg;
                           return Redirect("../");
                       }
                   }
                   string errorMsg1 = "Your credentials are invalid. Please try again.";
                   TempData["ErrorMessage"] = errorMsg1;
                   return Redirect("../");
               }
        */
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Access");
        }
        public IActionResult admin()
        {
            return View();
        }
    }
}
