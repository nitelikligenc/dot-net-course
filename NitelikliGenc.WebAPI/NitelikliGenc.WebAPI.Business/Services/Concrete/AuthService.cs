using Microsoft.AspNetCore.Identity;
using NitelikliGenc.WebAPI.Business.Services.Abstract;
using NitelikliGenc.WebAPI.Entities.DTOs;
using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.Business.Services.Concrete;

public class AuthService : IAuthService
{
    readonly ITokenService tokenService;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthService(ITokenService tokenService, UserManager<User> userManager, SignInManager<User> signInManager)
    {
        this.tokenService = tokenService;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    public async Task<LoginResponseDto> LoginUserAsync(LoginRequestDto request)
    {
        LoginResponseDto response = new();
        var user = await _userManager.FindByNameAsync(request.Username);
        if (user != null)
        {
            //var isLocked = await _userManager.IsLockedOutAsync(user);
            // var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, false, true);
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);
            if (!signInResult.Succeeded) return response;
            
            var generatedTokenInformation = await tokenService.GenerateToken(new TokenRequestDto() { Username = request.Username });

            response.AuthenticateResult = true;
            response.AuthToken = generatedTokenInformation.Token;
            response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
        }
        
        return response;
    }

    public async Task<IdentityResult> RegisterUserAsync(User user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<bool> UnlockUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return false;
        
        if (await _userManager.IsLockedOutAsync(user))
        {
            var identityResult = await _userManager.SetLockoutEndDateAsync(user, null);
            return identityResult.Succeeded;
        }
        return false;
    }
}