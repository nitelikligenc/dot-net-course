namespace NitelikliGenc.MVC.Entities.Entities;

public class Author : BaseEntity
{
    public string FullName { get; set; }
    public string About { get; set; }
    public string Gender { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string ImageUrl { get; set; }
    
    public virtual ICollection<Blog> Blogs { get; set; }
}