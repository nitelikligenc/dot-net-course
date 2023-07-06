namespace NitelikliGenc.WebAPI.Entities.DTOs;

public class CommentForDetailDto: BaseDto
{
    public string Text { get; set; }
    public ProductForSummaryDto Product  { get; set; }
}