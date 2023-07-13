using Microsoft.AspNetCore.Identity;
using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.Business.Helpers;

public class PasswordValidator : IPasswordValidator<User>
{
    public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
    {
        var errors = new List<IdentityError>();
        
        if (password.ToUpper().Contains(user.UserName.ToUpper().Trim()))
        {
            errors.Add(new IdentityError() {Code = "PasswordContainsUsername", Description = "Password can not contains userName."});
        }

        return Task.FromResult(errors.Any() ? IdentityResult.Failed(errors.ToArray()) : IdentityResult.Success);
    }
}