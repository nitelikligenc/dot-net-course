using Microsoft.AspNetCore.Identity;

namespace NitelikliGenc.WebAPI.Business.Helpers;

public class ErrorDescriber : IdentityErrorDescriber
{
    public override IdentityError InvalidUserName(string userName) => new()
        {Code = "InvalidUserName", Description = $"'{userName}' kulanıcı adı geçersiz."};
    
    public override IdentityError PasswordTooShort(int length) => new()
        {Code = "PasswordTooShort", Description = $"Şifre '{length}' karakterden az olamaz."};
}