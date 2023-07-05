using NitelikliGenc.WebAPI.Business.Services.Abstract;
using NitelikliGenc.WebAPI.DataAccess.Repositories;

namespace NitelikliGenc.WebAPI.Business.Services.Concrete;

public class BaseService<T> : IBaseService<T> where T : class
{
    private readonly IGenericRepository<T> _repository;

    public BaseService(IGenericRepository<T> repository)
    {
        _repository = repository;
    }
    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
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

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        return await _repository.UpdateAsync(entity);
    }
}