using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.MVC.Business.Services.Abstract;
using NitelikliGenc.MVC.Entities.Entities;

namespace NitelikliGenc.MVC.UI.Controllers;

[Authorize(Policy = "RequireAdmin")]
public class ContactController: Controller
{
    private readonly IBaseService<Contact> _service;
    public ContactController( IBaseService<Contact> service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    public  IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Contact contact)
    {
        var cont = await _service.AddAsync(contact);
        return View(cont);
    }
}