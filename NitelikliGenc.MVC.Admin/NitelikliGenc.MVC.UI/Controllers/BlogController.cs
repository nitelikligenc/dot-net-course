using Microsoft.AspNetCore.Mvc;

namespace NitelikliGenc.MVC.UI.Controllers;

public class BlogController: Controller
{
    public BlogController()
    {
        
    }

    public IActionResult Index()
    {
        List<Article> articles = new List<Article>
        {
            new Article{Id = 1, Title = "First Article", Date = DateTime.Now, CommentCount = 12, ViewCount = 200, Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book"},
            new Article{Id = 2, Title = "DotNet temelleri", Date = DateTime.Now, CommentCount = 1, ViewCount = 3, Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book"},
            new Article{Id = 3, Title = "Sık kullanılan html komutları", Date = DateTime.Now, CommentCount = 9, ViewCount = 24, Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book"},
            new Article{Id = 4, Title = "Css ip uçları", Date = DateTime.Now, CommentCount = 3, ViewCount = 5, Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book"},
        };
        return View(articles);
    }
    
    public IActionResult BlogDetail()
    {
        return View();
    }
    
    public class Article
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CommentCount { get; set; }
        public int ViewCount { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}