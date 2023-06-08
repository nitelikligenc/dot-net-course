namespace NitelikliGenc.DatabasePoC.Database.Models;

public class Books
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int PageNumber { get; set; }
    public double Price { get; set; }
    public virtual ICollection<Authors> Authors{ get; set; }
}