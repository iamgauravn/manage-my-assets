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
        public DbSet<Accessory> Accessory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserMaster>().HasData(new Models.UserMaster
            {
                Id = 1,
                Email = "admin@gmail.com",
                Password = "123",
                Username = "admin",
            });

            modelBuilder.Entity<Accessory>().HasData(new Accessory
            {
                Id = 1,
                Name = "Monitor",
                Description = "Display Screen"
            });

            modelBuilder.Entity<Accessory>().HasData(new Accessory
            {
                Id = 2,
                Name = "CPU",
                Description = "Central Processing Unit"
            });

            modelBuilder.Entity<Accessory>().HasData(new Accessory
            {
                Id = 3,
                Name = "Keyboard",
                Description = "For Input Typing"
            });


            modelBuilder.Entity<Accessory>().HasData(new Accessory
            {
                Id = 4,
                Name = "Mouse",
                Description = "Cursor Controlling"
            });

        }
    }
}
