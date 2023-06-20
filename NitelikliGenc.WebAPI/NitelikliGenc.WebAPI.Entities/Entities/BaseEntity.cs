using System.ComponentModel.DataAnnotations;

namespace NitelikliGenc.WebAPI.Entities.Entities;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public bool IsDeleted { get; set; }
}