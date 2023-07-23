using Microsoft.AspNetCore.Mvc;

namespace NitelikliGenc.MVC.UI.Controllers;

public class ContactController: Controller
{
    public ContactController()
    {
        
    }

    public IActionResult Index()
    {
        return View();
    }
}