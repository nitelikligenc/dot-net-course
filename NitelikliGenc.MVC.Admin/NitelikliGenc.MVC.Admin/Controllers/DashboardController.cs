using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NitelikliGenc.MVC.Admin.Controllers;

[Authorize]
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