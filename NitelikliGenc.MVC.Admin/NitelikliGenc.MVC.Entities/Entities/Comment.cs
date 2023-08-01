namespace NitelikliGenc.MVC.Entities.Entities;

public class Comment : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int Rate { get; set; }
    
    
}