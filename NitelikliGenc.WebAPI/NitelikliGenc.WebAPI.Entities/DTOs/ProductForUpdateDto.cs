namespace NitelikliGenc.WebAPI.Entities.DTOs;

public class ProductForUpdateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public Guid? CategoryId { get; set; }
}