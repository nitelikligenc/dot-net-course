using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using NitelikliGenc.WebAPI.Business.Mapping;
using NitelikliGenc.WebAPI.Business.Services.Categories;
using NitelikliGenc.WebAPI.Business.Services.Products;
using NitelikliGenc.WebAPI.DataAccess;
using NitelikliGenc.WebAPI.DataAccess.Repositories;
using NitelikliGenc.WebAPI.Entities.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
    .AddJsonOptions(option => option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();

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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();