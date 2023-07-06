using System.ComponentModel.DataAnnotations;
using NitelikliGenc.WebAPI.Entities.Enums;

namespace NitelikliGenc.WebAPI.Entities.Entities;

public class Product : BaseEntity
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Description is required.")]
    [StringLength(20, ErrorMessage = "Description must be less than 20 characters.")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Price is required.")]
    [Range(0.1, double.MaxValue)]
    public double Price { get; set; }
    
    [Required(ErrorMessage = "Currency is required.")]
    public Currency Currency { get; set; }
    
    [Required(ErrorMessage = "Stock is required.")]
    public int Stock { get; set; }

    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }
    public virtual ICollection<Comment>? Comments { get; set; }
    public virtual ICollection<Tag>? Tags { get; set; }
    public virtual ICollection<Like>? Likes { get; set; }
    public virtual ICollection<Rating>? Ratings { get; set; }
}