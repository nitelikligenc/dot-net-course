using Microsoft.AspNetCore.Mvc;

namespace NitelikliGenc.MVC.Admin.Controllers;

public class ExampleController : Controller
{
    public ExampleController()
    {
        
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
}