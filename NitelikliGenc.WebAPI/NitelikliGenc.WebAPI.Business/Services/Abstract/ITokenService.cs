using NitelikliGenc.WebAPI.Entities.DTOs;

namespace NitelikliGenc.WebAPI.Business.Services.Abstract;

public interface ITokenService
{
    public Task<TokenResponseDto> GenerateToken(TokenRequestDto request);
}