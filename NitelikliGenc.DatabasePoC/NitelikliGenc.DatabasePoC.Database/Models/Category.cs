namespace NitelikliGenc.DatabasePoC.Database.Models;

public class Category : BaseClass
{
    public string Name { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}