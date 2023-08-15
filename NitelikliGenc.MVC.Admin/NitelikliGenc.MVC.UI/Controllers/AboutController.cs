using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NitelikliGenc.MVC.UI.Controllers;

[Authorize]
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