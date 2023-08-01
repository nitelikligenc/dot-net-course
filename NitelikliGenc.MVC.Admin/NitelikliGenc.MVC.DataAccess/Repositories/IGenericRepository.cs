namespace NitelikliGenc.MVC.DataAccess.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdASync(int id);

    Task<IEnumerable<T>> GetAllAsync();

    Task<T> AddAsync(T entity);

    Task<bool> SaveAllAsync();

    Task<T> UpdateAsync(T entity);

    Task<bool> DeleteAsync(int id);
}