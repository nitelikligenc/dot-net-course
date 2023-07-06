using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.WebAPI.Business.Services.Abstract;
using NitelikliGenc.WebAPI.Entities.DTOs;
using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.API.Controllers;
[ApiController]
[Route("[controller]")]
public class CommentController: ControllerBase
{
    private readonly IBaseService<Comment> _service;
    private readonly IMapper _mapper;
    public CommentController(IBaseService<Comment> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var comments = await _service.GetAllAsync();
        
        return Ok(_mapper.Map<List<CommentForDetailDto>>(comments));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var comment = await _service.GetByIdAsync(id);
        if (comment == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<ProductsForCommentById>(comment));
    }

    [HttpPost]
    public async Task<IActionResult> Add(CommentForPostDto commentForPostDto)
    {
        var comment = _mapper.Map<Comment>(commentForPostDto);
        await _service.AddAsync(comment);
        return Ok(comment);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var comment = await _service.GetByIdAsync(id);
        if (comment == null)
        {
            return NotFound();
        }

        return await _service.DeleteAsync(id) ? NoContent() : throw new Exception();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, CommentForUpdateDto commentForUpdate)
    {
        var comment = await _service.GetByIdAsync(id);
        if (comment == null)
        {
            return NotFound();
        }

        var result = _mapper.Map(commentForUpdate, comment);
        await _service.UpdateAsync(result);
        return Ok(result);
    }
}