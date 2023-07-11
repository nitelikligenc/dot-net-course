using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NitelikliGenc.WebAPI.Business.Services.Abstract;
using NitelikliGenc.WebAPI.Entities.DTOs;

namespace NitelikliGenc.WebAPI.Business.Services.Concrete;

public class TokenService : ITokenService
{
    readonly IConfiguration configuration;

    public TokenService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    
    public async Task<TokenResponseDto> GenerateToken(TokenRequestDto request)
    {
        var dateTimeNow = DateTime.UtcNow;

        SymmetricSecurityKey symmetricSecurityKey =
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["AppSettings:Secret"]));
        
        JwtSecurityToken jwt = new JwtSecurityToken(
            issuer: configuration["AppSettings:ValidIssuer"],
            audience: configuration["AppSettings:ValidAudience"],
            claims: new List<Claim>
            {
                new Claim("userName", request.Username)
            },
            notBefore: dateTimeNow,
            expires: dateTimeNow.Add(TimeSpan.FromMinutes(5)),
            signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256));

        return await Task.FromResult(new TokenResponseDto()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(jwt),
            TokenExpireDate = dateTimeNow.Add(TimeSpan.FromMinutes(5))
        }); 
    }
}