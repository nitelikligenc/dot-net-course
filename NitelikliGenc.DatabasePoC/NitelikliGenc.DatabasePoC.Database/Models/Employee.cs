using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace NitelikliGenc.DatabasePoC.Database.Models;

public class Employee
{
    public int Id { get; set; }
    public int DepartmentId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public virtual Department Department { get; set; }
    
    // I you want to use data annotation, you can try below command lines.
    // [Key]
    // public int Id { get; set; }
    // [ForeignKey("DepId")]
    // public int DepartmentId { get; set; }
    // [MinLength(3)]
    // public string Name { get; set; }
    // [Range(1, 100, ErrorMessage = " Between 1 and 1000.")]
    // public int Age { get; set; }
    // [MaxLength(1)]
    // [MinLength(1)]
    // [DefaultValue("E")]
    // [Required(ErrorMessage = "Name is required")]
    // public string Gender { get; set; }
    // [EmailAddress(ErrorMessage = "Invalid email address")]
    // public string Email { get; set; }
    // [Phone(ErrorMessage = "Invalid phone number")]
    // public string Phone { get; set; }
    // public virtual Department Department { get; set; }
}