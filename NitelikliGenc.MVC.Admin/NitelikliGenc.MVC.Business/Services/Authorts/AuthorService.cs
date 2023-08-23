using NitelikliGenc.MVC.Business.Services.Abstract;
using NitelikliGenc.MVC.Business.Services.Concrete;
using NitelikliGenc.MVC.DataAccess.Repositories;
using NitelikliGenc.MVC.Entities.Entities;

namespace NitelikliGenc.MVC.Business.Services.Authorts;

public class AuthorService: BaseService<Author>, IAuthorService
{
    private readonly IAuthorRepository _repository;

    public AuthorService(IAuthorRepository repository): base(repository)
    {
        _repository = repository;
    }


    public async Task<Author?> GetByEmailAsync(string email)
    {
        return await _repository.GetByEmailASync(email);
    }
}