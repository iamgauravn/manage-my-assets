using manage_my_assets.Models;
using manage_my_assets.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace manage_my_assets.Controllers
{
    public class AccessoriesController : Controller
    {

        private readonly IBaseService<Accessory> _baseService;

        public AccessoriesController(IBaseService<Accessory> baseService)
        {
            _baseService = baseService;
        }

        public async Task<IActionResult> AddAccessoriesAsync(string accessoryName, string accessoryDescription)
        {
            var accessory = new Accessory
            {
                Name = accessoryName,
                Description = accessoryDescription
            };

            await _baseService.Create(accessory);

            return RedirectToAction("AddAccessories","Home");
        }
    }
}
