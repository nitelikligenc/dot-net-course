using NitelikliGenc.WebAPI.Entities.Enums;

namespace NitelikliGenc.WebAPI.Entities.DTOs;

public class ProductForListDto : BaseDto
{
    public string Name { get; set; }
    
    public string Price { get; set; }

}