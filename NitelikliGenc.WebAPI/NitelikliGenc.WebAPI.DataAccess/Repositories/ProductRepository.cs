using Microsoft.EntityFrameworkCore;
using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.DataAccess.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}