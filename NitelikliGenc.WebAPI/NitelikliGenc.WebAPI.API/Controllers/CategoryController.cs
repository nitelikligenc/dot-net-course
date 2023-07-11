using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.WebAPI.Business.Services.Abstract;
using NitelikliGenc.WebAPI.Entities.DTOs;
using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.API.Controllers;


[ApiController]
[Route("[controller]")]
[Authorize]
public class CategoryController : ControllerBase
{
    private readonly IBaseService<Category> _services;
    private readonly IMapper _mapper;
    public CategoryController(IBaseService<Category> services, IMapper mapper)
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
        var category = _mapper.Map<Category>(categoryForPostDto);
        await _services.AddAsync(category);
        return Ok(category);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var category = await _services.GetByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        return await _services.DeleteAsync(id) ? NoContent() : throw new Exception();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, CategoryForUpdateDto categoryForUpdateDto)
    {
        var category = await _services.GetByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        var pud = _mapper.Map(categoryForUpdateDto, category);
        await _services.UpdateAsync(pud);
        return Ok(pud);

    }
}