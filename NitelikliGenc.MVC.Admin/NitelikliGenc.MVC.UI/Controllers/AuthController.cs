using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.MVC.UI.Models;

namespace NitelikliGenc.MVC.UI.Controllers;

[AllowAnonymous]
public class AuthController: Controller
{
    public AuthController()
    {
        
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(SignInViewModel signInViewModel)
    {
        if (!ModelState.IsValid) return View();

        if (signInViewModel.Email == "Hüseyin" && signInViewModel.Password == "123")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, signInViewModel.Email),
                new Claim(ClaimTypes.Name, signInViewModel.Email),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties{};

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToAction("Index", "Home");
        }
        
        ModelState.AddModelError("Password", "Error : Invalid credentials.");
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();

        return RedirectToAction("Login");
    }
    
    public IActionResult Register()
    {
        return View();
    }
}