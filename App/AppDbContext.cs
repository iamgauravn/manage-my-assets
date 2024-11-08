using manage_my_assets.Models;
using Microsoft.EntityFrameworkCore;

namespace manage_my_assets.App
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserMaster> UserMaster { get; set; }

    }
}
