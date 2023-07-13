using Microsoft.AspNetCore.Identity;

namespace NitelikliGenc.WebAPI.Entities.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}