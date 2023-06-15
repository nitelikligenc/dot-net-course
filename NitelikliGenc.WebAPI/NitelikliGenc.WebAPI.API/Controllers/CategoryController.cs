using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.WebAPI.Business.Services.Categories;
using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.API.Controllers;
[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryServices _services;
    public CategoryController(ICategoryServices services)
    {
        _services = services;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _services.GetByIdAsync(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _services.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Add(Category category)
    {
        await _services.AddAsync(category);
        return Ok(category);
    }
}