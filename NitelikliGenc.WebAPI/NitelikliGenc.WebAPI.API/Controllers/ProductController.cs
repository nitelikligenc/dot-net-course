using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.WebAPI.Business.Services.Products;
using NitelikliGenc.WebAPI.Entities.DTOs;
using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.API.Controllers;

[ApiController]
[Route("[controller]")]
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
    
    // [HttpPost]
    // public async Task<IActionResult> Add(Product product)
    // {
    //     await _service.AddAsync(product);
    //     return Ok(product);
    // }

    [HttpPost("AddProduct")]
    public async Task<IActionResult> Add(ProductForPostDto productForPostDto)
    {
        var ppd = _mapper.Map<Product>(productForPostDto);
        await _service.AddAsync(ppd);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _service.DeleteAsync(id);
        if (result == null)
        {
            return NotFound();
        }

        return NoContent();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(ProductForUpdateDto productForUpdateDto)
    {
        var pud = _mapper.Map<Product>(productForUpdateDto);
        await _service.UpdateAsync(pud);
        return NoContent();

    }
}