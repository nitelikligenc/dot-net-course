
namespace NitelikliGenc.WebAPI.DataAccess.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(Guid id);

    Task<IEnumerable<T>> GetAllAsync();

    Task<T> AddAsync(T entity);
    
    Task<bool> SaveAllAsync();
}