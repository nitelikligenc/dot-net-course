using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.WebAPI.Business.Services.Categories;
using NitelikliGenc.WebAPI.Entities.DTOs;
using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.API.Controllers;
[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryServices _services;
    private readonly IMapper _mapper;
    public CategoryController(ICategoryServices services, IMapper mapper)
    {
        _services = services;
        _mapper = mapper;
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
    public async Task<IActionResult> Add(CategoryForPostDto categoryForPostDto)
    {
        var _category = _mapper.Map<Category>(categoryForPostDto);
        await _services.AddAsync(_category);
        return Ok(_category);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _services.DeleteAsync(id);
        if (result == null)
        {
            return NotFound();
        }

        return NoContent();
    }
    [HttpPut("/PutDto")]
    public async Task<IActionResult> Update(CategoryForUpdateDto productForUpdateDto)
    {
        var pud = _mapper.Map<Category>(productForUpdateDto);
        await _services.UpdateAsync(pud);
        return NoContent();

    }
}