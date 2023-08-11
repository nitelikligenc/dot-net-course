using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NitelikliGenc.MVC.Business.Services.Abstract;
using NitelikliGenc.MVC.Business.Services.Concrete;
using NitelikliGenc.MVC.DataAccess;
using NitelikliGenc.MVC.DataAccess.Repositories;
using NitelikliGenc.MVC.Entities.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
builder.Services.AddScoped<IBaseService<Category>, BaseService<Category>>();
builder.Services.AddScoped<IGenericRepository<Author>, GenericRepository<Author>>();
builder.Services.AddScoped<IBaseService<Author>, BaseService<Author>>();

builder.Services.AddDbContext<DataContext>(x =>
    x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        option =>
        {
            option.MigrationsAssembly(Assembly.GetAssembly(typeof(DataContext))?.GetName().Name);
        }
    ));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Database.Migrate();
}

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