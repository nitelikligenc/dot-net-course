namespace NitelikliGenc.MVC.Entities.Entities;

public class Contact : BaseEntity
{
    public string Mail { get; set; }
    public string PhoneNumber { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}