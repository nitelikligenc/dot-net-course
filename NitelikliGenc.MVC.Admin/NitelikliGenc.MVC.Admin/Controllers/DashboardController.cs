using Microsoft.AspNetCore.Mvc;

namespace NitelikliGenc.MVC.Admin.Controllers;

public class DashboardController: Controller
{
    public DashboardController()
    {
        
    }

    public IActionResult Dashboard()
    {
        return View();
    }
}