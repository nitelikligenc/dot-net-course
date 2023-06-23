using NitelikliGenc.WebAPI.DataAccess.Repositories;
using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.Business.Services.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Product> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Product> AddAsync(Product product)
    {
        await _repository.AddAsync(product);
        await _repository.SaveAllAsync();
        return product;
    }
    public Task<Product> DeleteAsync(Guid id)
    {
        return _repository.DeleteAsync(id);
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        await _repository.UpdateAsync(product);
        await _repository.SaveAllAsync();
        return product;
    }
}