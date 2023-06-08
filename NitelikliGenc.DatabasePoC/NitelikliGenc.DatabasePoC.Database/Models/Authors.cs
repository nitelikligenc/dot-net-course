namespace NitelikliGenc.DatabasePoC.Database.Models;

public class Authors
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Books> Books{ get; set; }
}