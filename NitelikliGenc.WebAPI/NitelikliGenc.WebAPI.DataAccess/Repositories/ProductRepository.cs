using Microsoft.EntityFrameworkCore;
using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.DataAccess.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<Product> GetByIdAsync(Guid id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}