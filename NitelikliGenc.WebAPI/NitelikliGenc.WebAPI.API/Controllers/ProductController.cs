using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.WebAPI.Business.Helpers;
using NitelikliGenc.WebAPI.Business.Services.Products;
using NitelikliGenc.WebAPI.Entities.DTOs;
using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;
    private readonly IMapper _mapper;


    public ProductController(IProductService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _service.GetByIdAsync(id);
        return Ok(_mapper.Map<ProductForDetailDto>(product));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _service.GetAllAsync();
        return Ok(_mapper.Map<List<ProductForListDto>>(products));
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(ProductForPostDto productForPostDto)
    {
        var ppd = _mapper.Map<Product>(productForPostDto);
        await _service.AddAsync(ppd);
        return Ok();
    }
    
    [ServiceFilter(typeof(NotFoundFilter))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var product = await _service.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return await _service.DeleteAsync(id) ? NoContent() : throw new Exception();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, ProductForUpdateDto productForUpdateDto)
    {
        var product = await _service.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        var pud = _mapper.Map(productForUpdateDto, product);
        await _service.UpdateAsync(pud);
        return Ok(pud);
    }
}