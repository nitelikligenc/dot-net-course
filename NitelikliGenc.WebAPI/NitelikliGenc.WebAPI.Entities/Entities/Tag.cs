namespace NitelikliGenc.WebAPI.Entities.Entities;

public class Tag: BaseEntity
{
    public string Label { get; set; }
    public virtual ICollection<Product>? Products { get; set; }
}