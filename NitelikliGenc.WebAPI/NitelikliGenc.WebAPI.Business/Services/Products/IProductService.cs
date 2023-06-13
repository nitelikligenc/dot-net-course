using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.Business.Services.Products;

public interface IProductService
{
    Task<Product> GetByIdAsync(Guid id);
    
    Task<IEnumerable<Product>> GetAllAsync();

    Task<Product> AddAsync(Product product);
}