using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using manage_my_assets.App;
using manage_my_assets.Models;

namespace manage_my_assets.Controllers
{
    public class UserMastersController : Controller
    {
        private readonly AppDbContext _context;

        public UserMastersController(AppDbContext context)
        {
            _context = context;
        }
         
        public async Task<IActionResult> Login()
        {
            return View();
        }

    }
}
