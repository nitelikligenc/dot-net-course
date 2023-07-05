
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace NitelikliGenc.WebAPI.DataAccess.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(Guid id);

    Task<IEnumerable<T>> GetAllAsync();

    Task<T> AddAsync(T entity);
    
    Task<bool> SaveAllAsync();

    Task<bool> DeleteAsync(Guid id);
    Task<T> UpdateAsync(T entity);
}