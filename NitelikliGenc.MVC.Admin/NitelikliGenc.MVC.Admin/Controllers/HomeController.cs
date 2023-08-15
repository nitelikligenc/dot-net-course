using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.MVC.Admin.Models;
using NitelikliGenc.MVC.Business.Services.Abstract;
using NitelikliGenc.MVC.Entities.Entities;

namespace NitelikliGenc.MVC.Admin.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly IBaseService<Category> _catService;
    private readonly IBaseService<Author> _authorService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, 
        IBaseService<Category> catService, 
        IBaseService<Author> authorService)
    {
        _logger = logger;
        _catService = catService;
        _authorService = authorService;
    }

    public async Task<IActionResult> Index()
    {
        var categoryCount = await _catService.GetAllAsync();
        var authorCount = await _authorService.GetAllAsync();
        ViewBag.catCount = categoryCount.Count();
        ViewBag.autCount = authorCount.Count();
        return View();
    }
}