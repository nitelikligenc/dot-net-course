using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.MVC.Admin.Models;

namespace NitelikliGenc.MVC.Admin.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}