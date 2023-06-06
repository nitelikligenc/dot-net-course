using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NitelikliGenc.DatabasePoC.Database.Database;
using NitelikliGenc.DatabasePoC.Database.Models;

namespace NitelikliGenc.DatabasePoC.Database.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    private readonly DataContext _dataContext;
    
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, DataContext dataContext)
    {
        _logger = logger;
        _dataContext = dataContext;
    }
    //
    // [HttpGet(Name = "GetWeatherForecast")]
    // public IEnumerable<WeatherForecast> Get()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //         {
    //             Date = DateTime.Now.AddDays(index),
    //             TemperatureC = Random.Shared.Next(-20, 55),
    //             Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //         })
    //         .ToArray();
    // }
    //
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var products = _dataContext.Products.ToList();
        return Ok(products);
    }

    [HttpPost]
    public IActionResult Post(ProductDto productDto)
    {
        var category = _dataContext.Categories.FirstOrDefault(x => x.Id == productDto.CategoryId);
        
        var product = new Product()
        {
            Id = productDto.Id,
            Name = productDto.Name,
            Price = productDto.Price,
            CategoryId = category.Id,
            Category = category
        };
        
        _dataContext.Products.Add(product);
        if (_dataContext.SaveChanges() > 0)
        {
            //return CreatedAtAction(nameof(GetById), new {id = product.Id}, product);
            return Ok(product);
        }
        return BadRequest();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product =_dataContext.Products.FirstOrDefault(x => x.Id == id);
        // var product = _dataContext.Products.Where(x => x.Id == id).FirstOrDefault();
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    public class ProductDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Id { get; set; }
        
        public int CategoryId { get; set; }
    }
    
    
}