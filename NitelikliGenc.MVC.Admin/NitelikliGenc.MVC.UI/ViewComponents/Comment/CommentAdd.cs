using Microsoft.AspNetCore.Mvc;

namespace NitelikliGenc.MVC.UI.ViewComponents.Comment;

public class CommentAdd: ViewComponent
{
    public CommentAdd()
    {
        
    }

    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        return View(id);
    }
}