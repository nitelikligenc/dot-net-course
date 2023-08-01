namespace NitelikliGenc.MVC.Entities.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    
    public virtual ICollection<Blog> Blogs { get; set; }
}