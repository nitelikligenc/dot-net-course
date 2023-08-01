using System.ComponentModel.DataAnnotations;

namespace NitelikliGenc.MVC.Entities.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? ModifiedAt { get; set; }
}