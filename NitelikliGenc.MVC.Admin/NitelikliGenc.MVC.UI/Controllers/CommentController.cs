using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NitelikliGenc.MVC.Business.Services.Abstract;
using NitelikliGenc.MVC.Entities.Entities;

namespace NitelikliGenc.MVC.UI.Controllers;

public class CommentController: Controller
{
    private readonly IBaseService<Comment> _commentService;
    public CommentController(IBaseService<Comment> commentService)
    {
        _commentService = commentService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Comment c)
    {
        // if (!ModelState.IsValid)
        // {
        //     return Json(new { success = false, message = "Ekleme yaparken hata oluştu." });
        // }
        var comment = new Comment
        {
            Title = c.Title,
            Content = c.Content,
            BlogId = c.BlogId,
            Rate = 2,
            UserId = 1
        };
        await _commentService.AddAsync(comment);
        return Json(new { success = true });
    }

    // public async Task<PartialViewResult> Create()
    // {
    //     return PartialView();
    // }

}