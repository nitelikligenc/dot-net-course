using NitelikliGenc.MVC.Business.Services.Concrete;
using NitelikliGenc.MVC.DataAccess.Repositories;
using NitelikliGenc.MVC.Entities.Entities;

namespace NitelikliGenc.MVC.Business.Services.Blogs;

public class BlogService: BaseService<Blog>, IBlogService
{
    private readonly IBlogRepository _repository;

    public BlogService(IBlogRepository repository): base(repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Blog?>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}