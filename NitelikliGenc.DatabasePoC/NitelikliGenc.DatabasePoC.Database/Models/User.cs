using System.ComponentModel.DataAnnotations;

namespace NitelikliGenc.DatabasePoC.Database.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    [MaxLength(20)]
    [MinLength(3)]
    public string Username { get; set; }
    public virtual UserProfile UserProfile { get; set; }
}