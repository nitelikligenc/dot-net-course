using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NitelikliGenc.MVC.Admin.Controllers;

[Authorize]
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