using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NitelikliGenc.DatabasePoC.Database.Database;
using NitelikliGenc.DatabasePoC.Database.Models;

namespace NitelikliGenc.DatabasePoC.Database.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly DataContext _dataContext;

    public CategoryController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var categories = _dataContext.Categories.Include(x => x.Products).ToList();
        return Ok(categories);
    }

    [HttpPost]
    public IActionResult Post(CategoryDto categoryDto)
    {
        var category = new Category()
        {
            Id = categoryDto.Id,
            Name = categoryDto.Name
        };
        
        _dataContext.Categories.Add(category);
        if (_dataContext.SaveChanges() > 0)
        {
            return CreatedAtAction(nameof(GetById), new {id = category.Id}, category);
        }
        return BadRequest();
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var category =_dataContext.Categories.Include(x => x.Products).FirstOrDefault(x => x.Id == id);
        // var product = _dataContext.Products.Where(x => x.Id == id).FirstOrDefault();
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }
    
    public class CategoryDto
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}