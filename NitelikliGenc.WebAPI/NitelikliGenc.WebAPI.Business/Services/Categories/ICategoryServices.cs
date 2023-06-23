using NitelikliGenc.WebAPI.Entities.DTOs;
using NitelikliGenc.WebAPI.Entities.Entities;
namespace NitelikliGenc.WebAPI.Business.Services.Categories;

public interface ICategoryServices
{
    Task<Category> GetByIdAsync(Guid id);
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category> AddAsync(Category category);
    Task<Category> DeleteAsync(Guid id);
    Task<Category> UpdateAsync(Category product);
}