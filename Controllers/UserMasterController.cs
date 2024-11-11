using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using manage_my_assets.Service.Interface;

namespace manage_my_assets.Controllers
{
    public class UserMasterController : Controller
    {

        private readonly IUserMasterService _userMasterService;

        public UserMasterController(IUserMasterService userMasterService)
        {
            _userMasterService = userMasterService;
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                TempData["Error"] = "Email and password are required.";
                return RedirectToAction("Index", "Home"); 
            }
             
            if (!_userMasterService.authUser(email, password))
            {
                TempData["Error"] = "Invalid email or password.";
                return RedirectToAction("Index", "Home");
            } else
            {
                
            }
             
            return RedirectToAction("Index","Home");
        }
          
    }
}
