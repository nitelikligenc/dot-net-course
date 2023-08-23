namespace NitelikliGenc.MVC.Entities.Entities;

public class Comment : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int Rate { get; set; }
    public int BlogId { get; set; }
    public virtual Blog Blog { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
}   