namespace NitelikliGenc.WebAPI.Entities.Entities;

public class Like: BaseEntity
{
    public bool isLiked { get; set; }
    public Guid? ProductId { get; set; }
    public Product? Product { get; set; }
}