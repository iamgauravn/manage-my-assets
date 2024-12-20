using manage_my_assets.Models;
using manage_my_assets.Service.Interface;
using manage_my_assets.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace manage_my_assets.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBaseService<Accessory> baseService;

        public HomeController(ILogger<HomeController> logger, IBaseService<Accessory> baseService)
        {
            _logger = logger;
            this.baseService = baseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        } 

        public IActionResult AddAssets()
        { 
            return View();
        } 

        public IActionResult AddAccessories()
        { 
            return View();
        } 

        public IActionResult AssetsAllocatment()
        {
            return View();
        } 

        public IActionResult AllocatmentHistory()
        {
            return View();
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
