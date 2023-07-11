using NitelikliGenc.WebAPI.Business.Services.Abstract;
using NitelikliGenc.WebAPI.Entities.DTOs;

namespace NitelikliGenc.WebAPI.Business.Services.Concrete;

public class AuthService : IAuthService
{
    readonly ITokenService tokenService;

    public AuthService(ITokenService tokenService)
    {
        this.tokenService = tokenService;
    }
    public async Task<LoginResponseDto> LoginUserAsync(LoginRequestDto request)
    {
        LoginResponseDto response = new();
        
        // şimdilik statik bir sonraki ders user tablosu eklenecek
        if (request.Username == "huseyin" && request.Password == "123456") 
        {
            var generatedTokenInformation = await tokenService.GenerateToken(new TokenRequestDto() { Username = request.Username });

            response.AuthenticateResult = true;
            response.AuthToken = generatedTokenInformation.Token;
            response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;          
        }

        return response;
    }
}