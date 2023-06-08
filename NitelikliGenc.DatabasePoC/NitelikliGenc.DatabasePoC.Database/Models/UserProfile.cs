using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NitelikliGenc.DatabasePoC.Database.Models;

public class UserProfile
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("UsId")]
    public int UserId { get; set; }
    [MaxLength(50)]
    [MinLength(3)]
    [Required(ErrorMessage = "Fullname is required")]
    public string Fullname { get; set; }
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }

    public virtual User User { get; set; }
}