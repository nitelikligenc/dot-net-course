using NitelikliGenc.MVC.Entities.Entities;
namespace NitelikliGenc.MVC.Admin.Models.ViewModels.Blog;

public class BlogCreateViewModel
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int CategoryId { get; set; }

    public IFormFile ImageFile { get; set; }
    // public IFormFile ThumbnailImageUrl { get; set; }
    public IEnumerable<Entities.Entities.Category> Categories { get; set; }
}