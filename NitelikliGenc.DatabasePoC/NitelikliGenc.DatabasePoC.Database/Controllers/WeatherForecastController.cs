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

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
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
    public List<Product> Get()
    {
        DataContext _dataContext = new DataContext();
        var _products = _dataContext.Products.ToList(); ;
        return _products;
    }
}