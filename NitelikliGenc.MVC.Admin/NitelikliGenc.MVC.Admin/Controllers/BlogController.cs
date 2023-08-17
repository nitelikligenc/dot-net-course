using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.MVC.Admin.Models.ViewModels.Blog;
using NitelikliGenc.MVC.Business.Services.Abstract;
using NitelikliGenc.MVC.Entities.Entities;

namespace NitelikliGenc.MVC.Admin.Controllers;

[Authorize]
public class BlogController: Controller
{
    private readonly IBaseService<Blog> _blogService;
    private readonly IBaseService<Category> _categoryService;
    private readonly UserManager<User> _userManager;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public BlogController(IBaseService<Blog> blogService, 
        IBaseService<Category> categoryService, 
        UserManager<User> userManager,
        IWebHostEnvironment webHostEnvironment)
    {
        _blogService = blogService;
        _categoryService = categoryService;
        _userManager = userManager;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<IActionResult> Index()
    {
        var blogs = await _blogService.GetAllAsync();
        return View(blogs);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var categories = await _categoryService.GetAllAsync();
        var model = new BlogCreateViewModel
        {
            Categories = categories
        };
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(BlogCreateViewModel bvm)
    {
        
        var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "files");
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(bvm.ImageFile.FileName);
        var filePath = Path.Combine(imagePath, fileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await bvm.ImageFile.CopyToAsync(fileStream);
        }

        var blog = new Blog
        {
            Title = bvm.Title,
            Content = bvm.Content,
            CategoryId = bvm.CategoryId,
            AuthorId = GetCurrentUserId(),
            ThumbnailImageUrl = "assets",
            ImageUrl = fileName
        };
        await _blogService.AddAsync(blog);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var blog = await _blogService.GetByIdAsync(id);
        if (blog == null)
        {
            return RedirectToAction("Index");
        }

        await _blogService.DeleteAsync(id);
        return View("Index");
    }
    [HttpGet]
    public async Task<IActionResult> Delete2(int id)
    {
        var blog = await _blogService.GetByIdAsync(id);
        if (blog == null)
        {
            return RedirectToAction("Index");
        }
        return Json(blog);
    }

    private int GetCurrentUserId()
    {
        var userId = _userManager.GetUserId(User);
        return Convert.ToInt32(userId);
    }
}