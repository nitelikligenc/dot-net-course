namespace NitelikliGenc.WebAPI.Entities.Entities;

public class Comment: BaseEntity
{
    public string Text { get; set; }
    
    public Guid? ProductId { get; set; }
    public Product? Product { get; set; }
}