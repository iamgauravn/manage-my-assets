using manage_my_assets.App;
using manage_my_assets.Service.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace manage_my_assets.Service.Implementation
{
    public class UserMasterService : IUserMasterService
    {

        private readonly AppDbContext _context;

        public UserMasterService(AppDbContext context)
        {
            _context = context;
        }

        public bool authUser(string email, string password)
        {
            var _userMaster = _context.UserMaster.FirstOrDefault(d=>d.Email == email && d.Password == password);  

            if (_userMaster == null)
            {
                return false;
            }

            return true;

        }
         
    }
}
