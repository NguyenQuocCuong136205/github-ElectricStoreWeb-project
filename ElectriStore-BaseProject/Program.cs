using ElectriStore_BaseProject.Models;
using ElectriStore_BaseProject.Repositories.Brands;
using ElectriStore_BaseProject.Repositories.Product;
using ElectriStore_BaseProject.Repositories.Products;
using ElectriStore_BaseProject.Repositories.Users;
using ElectriStore_BaseProject.Services.Brands;
using ElectriStore_BaseProject.Services.Products;
using ElectriStore_BaseProject.Services.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// lấy chuỗi kết nối từ appsetting
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//dependency injection
builder.Services.AddDbContext<ElectronicStoreContext>(options => options.UseSqlServer(connectionString));

// thêm repositories vào DI container
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductDTORepository, ProductDTORepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();

// thêm services vào DI container
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBrandService, BrandService>();

// Đăng ký Cookie Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/User/Login";
        options.AccessDeniedPath = "/User/AccessDenied";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication(); // Kích hoạt xác thực Cookie
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
