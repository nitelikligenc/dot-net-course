using NitelikliGenc.MVC.Business.Services.Abstract;
using NitelikliGenc.MVC.DataAccess.Repositories;

namespace NitelikliGenc.MVC.Business.Services.Concrete;

public class BaseService<T> : IBaseService<T> where T : class
{
    private readonly IGenericRepository<T> _repository;

    public BaseService(IGenericRepository<T> repository)
    {
        _repository = repository;
    }
    
    public async Task<T?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdASync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _repository.AddAsync(entity);
        await _repository.SaveAllAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        return await _repository.UpdateAsync(entity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}