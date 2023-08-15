using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NitelikliGenc.MVC.Admin.Controllers;

[Authorize]
public class UserController: Controller
{
    public UserController()
    {
        
    }

    public IActionResult Index()
    {
        List<User> users = new List<User>
        {
            new User {Id = 1, Name = "Levent", Surname = "Koman", Username = "leventkoman", PhoneNUmber = "0538222222"},
            new User {Id = 2, Name = "Fatih", Surname = "Öz", Username = "fatihoz", PhoneNUmber = "0538222222"},
            new User {Id = 3, Name = "Şevval", Surname = "Ger", Username = "sevvalger", PhoneNUmber = "0538222222"},
            new User
            {
                Id = 4, Name = "Alperen", Surname = "Türksoy", Username = "alperenturksoy", PhoneNUmber = "0538222222"
            }
        };
        return View(users);
    }
    
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string PhoneNUmber { get; set; }
    }
}