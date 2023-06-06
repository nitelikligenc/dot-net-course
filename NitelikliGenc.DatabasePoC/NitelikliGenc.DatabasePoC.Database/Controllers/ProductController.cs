using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NitelikliGenc.DatabasePoC.Database.Database;
using NitelikliGenc.DatabasePoC.Database.Models;

namespace NitelikliGenc.DatabasePoC.Database.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly DataContext _dataContext;
    
    public ProductController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var products = _dataContext.Products.Include(x => x.Category).ToList();
        return Ok(products);
    }

    [HttpPost]
    public IActionResult Post(ProductDto productDto)
    {
        var category = _dataContext.Categories.FirstOrDefault(x => x.Id == productDto.CategoryId);
        if (category == null) return NotFound();
        
        var product = new Product()
        {
            Id = productDto.Id,
            Name = productDto.Name,
            Price = productDto.Price,
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
        var product =_dataContext.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
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