using NitelikliGenc.WebAPI.Entities.DTOs;

namespace NitelikliGenc.WebAPI.Business.Services.Abstract;

public interface IAuthService
{
    public Task<LoginResponseDto> LoginUserAsync(LoginRequestDto request);

}