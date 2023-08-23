using NitelikliGenc.MVC.Entities.Entities;

namespace NitelikliGenc.MVC.DataAccess.Repositories;

public interface IAuthorRepository: IGenericRepository<Author>
{
    Task<Author?> GetByEmailASync(string email);
}