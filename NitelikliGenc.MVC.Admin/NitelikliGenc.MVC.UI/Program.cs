using System.Reflection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using NitelikliGenc.MVC.Business.Services.Abstract;
using NitelikliGenc.MVC.Business.Services.Concrete;
using NitelikliGenc.MVC.DataAccess;
using NitelikliGenc.MVC.DataAccess.Repositories;
using NitelikliGenc.MVC.Entities.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
        {
            opt.LoginPath = "/Auth/Login";
        }
    );

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin"));
});

builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IGenericRepository<Contact>, GenericRepository<Contact>>();
builder.Services.AddScoped<IBaseService<Contact>, BaseService<Contact>>();
builder.Services.AddScoped<IGenericRepository<Blog>, GenericRepository<Blog>>();
builder.Services.AddScoped<IBaseService<Blog>, BaseService<Blog>>();

// builder.Services.AddDbContext<DataContext>(x =>
//     x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
//         option =>
//         {
//             option.MigrationsAssembly(Assembly.GetAssembly(typeof(DataContext))?.GetName().Name);
//         }
//     ));
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();