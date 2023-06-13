using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.DataAccess.Repositories;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(Guid id);
    
    Task<IEnumerable<Product>> GetAllAsync();

    Task AddAsync(Product product);

    Task<bool> SaveAllAsync();
}