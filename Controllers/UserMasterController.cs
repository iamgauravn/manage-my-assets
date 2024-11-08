using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace manage_my_assets.Controllers
{
    public class UserMasterController : Controller
    {
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                TempData["Error"] = "Email and password are required.";
                return RedirectToAction("Index"); 
            }
             
            if (false)
            {
                TempData["Error"] = "Invalid email or password.";
                return RedirectToAction("Index");
            } else
            {
                storeLogin(email, password);
            }
             
            return RedirectToAction("Index","Home");
        }

        private async void storeLogin(string username, string password)
        {
            var claims = new List<Claim>
            {
                new Claim(username, password),
            };
            // Creating identity and principal for the authenticated user
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            // Signing in the user using cookie authentication
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // Sign the user out using the specified authentication scheme.
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            // Redirect the user to the login page after successful logout.
            return RedirectToAction("Login", "Home");
        }
    }
}
