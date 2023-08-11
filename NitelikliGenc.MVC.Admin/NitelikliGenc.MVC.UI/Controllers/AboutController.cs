using Microsoft.AspNetCore.Mvc;

namespace NitelikliGenc.MVC.UI.Controllers;

public class AboutController: Controller
{
    public AboutController()
    {
        
    }

    public IActionResult Index()
    {
        return View();
    }
}