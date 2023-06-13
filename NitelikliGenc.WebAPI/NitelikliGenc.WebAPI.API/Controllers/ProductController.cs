using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.WebAPI.Business.Services.Products;
using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;


    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(Product product)
    {
        await _service.AddAsync(product);
        return Ok(product);
    }
}