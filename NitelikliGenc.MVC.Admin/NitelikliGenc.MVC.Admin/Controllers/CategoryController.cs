using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NitelikliGenc.MVC.Admin.Models.ViewModels.Category;
using NitelikliGenc.MVC.Business.Services.Abstract;
using NitelikliGenc.MVC.Business.ValidatorRules;
using NitelikliGenc.MVC.Entities.Entities;

namespace NitelikliGenc.MVC.Admin.Controllers;

[Authorize]
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
    public async Task<IActionResult> Create(CategoryCreateViewModel catViewModel)
    {
        var cat = new Category
        {
            Description = catViewModel.Description,
            Name = catViewModel.Name
        };
        await _service.AddAsync(cat);
        return RedirectToAction("Index");
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
        return RedirectToAction("Index");
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
        CategoryUpdateValidator categoryUpdateValidator = new CategoryUpdateValidator();
        ValidationResult result = categoryUpdateValidator.Validate(category);

        if (!result.IsValid)
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
        else
        {
            await _service.UpdateAsync(category);
            return RedirectToAction("Index");
        }
        
        return View(category);
    }
    
    public class ViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}