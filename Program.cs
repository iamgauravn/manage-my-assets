using manage_my_assets.App;
using manage_my_assets.Service.Implementation;
using manage_my_assets.Service.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("ManagerConnectionString")));

builder.Services.AddAuthentication((options) => {
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme; 
  options.DefaultSignInScheme =
    CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme =
      CookieAuthenticationDefaults.AuthenticationScheme;
    // Set the default scheme used to challenge authentication
    options.DefaultChallengeScheme =
      CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie((options) => {
    // Set the login path where the user will be redirected for authentication
    options.LoginPath = "/Home/Login";
    // Set the access denied path where the user will be redirected when access is denied
    options.AccessDeniedPath = "/Home/Index";
});


builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
