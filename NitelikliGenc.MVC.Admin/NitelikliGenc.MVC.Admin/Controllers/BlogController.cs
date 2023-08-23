using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.MVC.Admin.Models.ViewModels.Blog;
using NitelikliGenc.MVC.Business.Services.Abstract;
using NitelikliGenc.MVC.Business.Services.Authorts;
using NitelikliGenc.MVC.Business.Services.Blogs;
using NitelikliGenc.MVC.Entities.Entities;

namespace NitelikliGenc.MVC.Admin.Controllers;

[Authorize]
public class BlogController: Controller
{
    private readonly IBaseService<Blog> _blogService;
    private readonly IBlogService _customBlogService;
    private readonly IBaseService<Category> _categoryService;
    private readonly IAuthorService _authorService;
    private readonly UserManager<User> _userManager;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public BlogController(IBaseService<Blog> blogService, 
        IBlogService customBlogService,
        IBaseService<Category> categoryService, 
        IAuthorService authorService, 
        UserManager<User> userManager,
        IWebHostEnvironment webHostEnvironment)
    {
        _blogService = blogService;
        _customBlogService = customBlogService;
        _categoryService = categoryService;
        _authorService = authorService;
        _userManager = userManager;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<IActionResult> Index()
    {
        var blogs = await _customBlogService.GetAllAsync();
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
        
        var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
        if (!Directory.Exists(imagePath))
        {
            Directory.CreateDirectory(imagePath);
        }
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(bvm.ImageFile.FileName);
        var filePath = Path.Combine(imagePath, fileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await bvm.ImageFile.CopyToAsync(fileStream);
        }
        
        if (GetCurrentUserId() == -1)
        {
            return RedirectToAction("Index");
        }
        
        var blog = new Blog 
        {
            Title = bvm.Title,
            Content = bvm.Content,
            CategoryId = bvm.CategoryId,
            AuthorId = 1,
            ThumbnailImageUrl = "assets",
            ImageUrl = fileName
        };
        await _blogService.AddAsync(blog);
        return RedirectToAction("Index");
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
        var user = _userManager.GetUserAsync(User);
        var userEmail = user.Result.Email;
        var userId = user.Result.Id;
        var author = _authorService.GetByEmailAsync(userEmail);
            
        if (userId != author?.Result?.Id)
        {
            return -1;
        }
        return Convert.ToInt32(userId);
    }
    
    
    //Todo you can remove files from wwwroot directory with below code lines
    // var existingBlog = await _blogService.GetByIdAsync(blogCreate.Id);
    //     if (existingBlog == null)
    // {
    //     return RedirectToAction("Index");
    // }
    // else
    // {
    //     var existingImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", existingBlog.ImageUrl);
    //     if (System.IO.File.Exists(existingImagePath))
    //     {
    //         System.IO.File.Delete(existingImagePath);
    //     }
    // }
}