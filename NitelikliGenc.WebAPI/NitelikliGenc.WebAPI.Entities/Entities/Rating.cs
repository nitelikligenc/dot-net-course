using System.ComponentModel.DataAnnotations;

namespace NitelikliGenc.WebAPI.Entities.Entities;

public class Rating: BaseEntity
{
    [Range(1,5)]
    public int Value { get; set; }

    public Guid? productId { get; set; }
    public Product? Product { get; set; }
}