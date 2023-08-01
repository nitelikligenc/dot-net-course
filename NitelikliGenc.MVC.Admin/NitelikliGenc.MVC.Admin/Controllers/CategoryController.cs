using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.MVC.Business.Services.Abstract;
using NitelikliGenc.MVC.Entities.Entities;

namespace NitelikliGenc.MVC.Admin.Controllers;

public class CategoryController : Controller
{
    private readonly IBaseService<Category> _service;

    public CategoryController(IBaseService<Category> service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _service.GetAllAsync();
        return View(categories);
    }
}