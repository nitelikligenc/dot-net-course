using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.MVC.Business.Services.Abstract;

namespace NitelikliGenc.MVC.UI.ViewComponents.Comment;

public class CommentList: ViewComponent
{
    private readonly IBaseService<Entities.Entities.Comment> _commentService;
    private readonly IBaseService<Entities.Entities.Blog> _bloBaseService;
    public CommentList(IBaseService<Entities.Entities.Comment> commentService,
        IBaseService<Entities.Entities.Blog> bloBaseService)
    {
        _commentService = commentService;
        _bloBaseService = bloBaseService;
    }

    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        var blog = await _bloBaseService.GetByIdAsync(id);
        var comments = await _commentService.GetAllAsync();
        return View(blog.Comments);
    }
}