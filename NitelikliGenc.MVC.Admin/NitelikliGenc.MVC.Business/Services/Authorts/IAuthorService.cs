using NitelikliGenc.MVC.Business.Services.Abstract;
using NitelikliGenc.MVC.Entities.Entities;

namespace NitelikliGenc.MVC.Business.Services.Authorts;

public interface IAuthorService: IBaseService<Author>
{
    Task<Author?> GetByEmailAsync(string email);
}