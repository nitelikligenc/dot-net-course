namespace NitelikliGenc.MVC.Entities.Entities;

public class Blog : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string ThumbnailImageUrl { get; set; }
    public string ImageUrl { get; set; }
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    public int AuthorId { get; set; }
    public Author Author { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
}