using Microsoft.AspNetCore.Identity;
using NitelikliGenc.WebAPI.Entities.DTOs;
using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.Business.Services.Abstract;

public interface IAuthService
{
    public Task<LoginResponseDto> LoginUserAsync(LoginRequestDto request);
    public Task<IdentityResult> RegisterUserAsync(User user, string password);
    Task<bool> UnlockUser(string id);

}