using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.MVC.Business.Services.Abstract;
using NitelikliGenc.MVC.Entities.Entities;

namespace NitelikliGenc.MVC.UI.Controllers;

[Authorize]
public class BlogController: Controller
{
    private readonly IBaseService<Blog> _blogService;
    public BlogController(IBaseService<Blog> blogService)
    {
        _blogService = blogService;
    }

    public async Task<IActionResult> Index()
    {
        var blogs = await _blogService.GetAllAsync();
        return View(blogs);
    }
    
    public async Task<IActionResult> BlogDetail(int id)
    {
        var blog = await _blogService.GetByIdAsync(id);
        if (blog == null)
        {
            return RedirectToAction("Index");
        }
        
        if (blog.Comments == null)
        {
            ViewBag.CommentCount = 0;
        }
        else
        {
            ViewBag.CommentCount = blog.Comments.Count();
        }

        ViewBag.blogId = id;
        return View(blog);
    }
    
}