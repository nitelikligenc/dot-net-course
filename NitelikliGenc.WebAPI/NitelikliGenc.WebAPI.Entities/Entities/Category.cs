using System.ComponentModel.DataAnnotations;

namespace NitelikliGenc.WebAPI.Entities.Entities;

public class Category : BaseEntity
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Description is required.")]
    [StringLength(20, ErrorMessage = "Description must be less than 20 characters.")]
    public string Description { get; set; }
    
    public int Order { get; set; }
    
    public virtual ICollection<Product>? Products { get; set; }
}