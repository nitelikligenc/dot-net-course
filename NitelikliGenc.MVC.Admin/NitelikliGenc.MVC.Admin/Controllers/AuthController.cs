using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.MVC.Admin.Models.ViewModels.Auth;
using NitelikliGenc.MVC.Entities.Entities;

namespace NitelikliGenc.MVC.Admin.Controllers;

[AllowAnonymous]
public class AuthController: Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(SignInViewModel signInViewModel)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByNameAsync(signInViewModel.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, signInViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    await _userManager.ResetAccessFailedCountAsync(user);

                    return RedirectToAction("Index", "Home");
                }

                if (result.IsLockedOut)
                {
                    var lockoutEndTime = await _userManager.GetLockoutEndDateAsync(user);
                    ModelState.AddModelError("Password", $"Account Locked. Locked End = {lockoutEndTime}");
                }
            }
            else
            {
                ModelState.AddModelError("Password", "Error : Invalid Credentials.");
            }
        }
        return View();
    }
    
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        
        return RedirectToAction("Login");
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        if (ModelState.IsValid)
        {
            var user = new User()
            {
                FullName = registerViewModel.FullName,
                UserName = registerViewModel.Email,
                Email = registerViewModel.Email
            };

            var result = await _userManager.CreateAsync(user, registerViewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
        }
        return View();
    }
}