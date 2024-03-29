using Microsoft.AspNetCore.Identity;

namespace NitelikliGenc.MVC.Entities.Entities;

public class User : IdentityUser<int>
{
    public string FullName { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
}