using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AksApp.Models;
using AksApp.Data;

namespace AksApp.Controllers
{
    

    public class AccessController : Controller
    {
        public ApplicationDbContext _db;

        public AccessController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("admin", "Admin");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserCredentials modelLogin)

        {
            if (modelLogin.Email == _db.userCredentials.Find(2).Email && modelLogin.Password == _db.userCredentials.Find(2).Password
                )
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
                    new Claim("OtherProperties", "Example Role")
                };

                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = modelLogin.KeepLoggedIn

                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), properties);
                return RedirectToAction("admin", "Admin");
            }
            string errMsg = " User Not Found";
            ViewData["ErrorMessage"] = errMsg;
            return View();
        }
    }
}
