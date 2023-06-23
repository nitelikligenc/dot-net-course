using NitelikliGenc.WebAPI.DataAccess.Repositories;
using NitelikliGenc.WebAPI.Entities.DTOs;
using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.Business.Services.Categories;

public class CategoryServices : ICategoryServices
{
    private readonly IGenericRepository<Category> _repository;
    public CategoryServices(IGenericRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<Category> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Category> AddAsync(Category category)
    {
        await _repository.AddAsync(category);
        await _repository.SaveAllAsync();
        return category;
    }

    public Task<Category> DeleteAsync(Guid id)
    {
        return _repository.DeleteAsync(id);
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        await _repository.UpdateAsync(category);
        await _repository.SaveAllAsync();
        return category;
    }
}