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
    
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Category category)
    {
        var _category = await _service.AddAsync(category);
        return View(_category);
    }

    [HttpGet]
    public async Task<IActionResult> Detail(int id)
    {
        var cat = await _service.GetByIdAsync(id);
        if (cat == null)
        {
            return RedirectToPage("Index");
        }
        return View(cat);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var cat = await _service.GetByIdAsync(id);
        if (cat == null)
        {
            return RedirectToPage("Index");
        }
        await _service.DeleteAsync(id);
        return View("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var cat = await _service.GetByIdAsync(id);
        if (cat == null)
        {
            return RedirectToPage("Index");
        }
        
        return View(cat);
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(Category category)
    {
        var _category = await _service.UpdateAsync(category);
        return View(_category);
    }
}