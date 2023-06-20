using NitelikliGenc.WebAPI.Entities.Enums;

namespace NitelikliGenc.WebAPI.Entities.DTOs;

public class ProductForDetailDto : BaseDto
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public double Price { get; set; }
    
    public Currency Currency { get; set; }
    
    public int Stock { get; set; }
    
    public DateTime CreatedAt { get; set; }
}