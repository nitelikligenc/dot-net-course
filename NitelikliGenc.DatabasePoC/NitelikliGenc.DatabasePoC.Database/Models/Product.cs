namespace NitelikliGenc.DatabasePoC.Database.Models;

public class Product : BaseClass
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
}