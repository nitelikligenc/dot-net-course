using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NitelikliGenc.MVC.Business.Services.Abstract;
using NitelikliGenc.MVC.DataAccess;
using NitelikliGenc.MVC.DataAccess.Repositories;
using NitelikliGenc.MVC.Entities.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IGenericRepository<Contact>, IGenericRepository<Contact>>();
builder.Services.AddScoped<IBaseService<Contact>, IBaseService<Contact>>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();