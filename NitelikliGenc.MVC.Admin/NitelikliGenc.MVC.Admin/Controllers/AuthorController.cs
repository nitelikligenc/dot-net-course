using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.MVC.Business.Services.Abstract;
using NitelikliGenc.MVC.Business.Services.Authorts;
using NitelikliGenc.MVC.Entities.Entities;

namespace NitelikliGenc.MVC.Admin.Controllers;

public class AuthorController: Controller
{
    private readonly IBaseService<Author> _service;
    private readonly IAuthorService _authorService;
    public AuthorController(IBaseService<Author> service, IAuthorService authorService)
    {
        _service = service;
        _authorService = authorService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var authors = await _service.GetAllAsync();
        return View(authors);
    }
    
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Author author)
    {
        author.ImageUrl = "assets";
        var getAuthorEmail = await _authorService.GetByEmailAsync(author.Email);
        if (getAuthorEmail != null)
        {
            ModelState.AddModelError("Email", "Bu email adresi zaten kullanılıyor.");
            return View(author);
        }

        await _service.AddAsync(author);

        return RedirectToAction("Index");
    }
}