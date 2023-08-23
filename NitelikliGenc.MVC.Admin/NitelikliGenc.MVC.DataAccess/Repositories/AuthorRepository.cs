using Microsoft.EntityFrameworkCore;
using NitelikliGenc.MVC.Entities.Entities;

namespace NitelikliGenc.MVC.DataAccess.Repositories;

public class AuthorRepository: GenericRepository<Author>, IAuthorRepository
{
    private readonly DataContext _context;

    public AuthorRepository(DataContext context): base(context)
    {
        _context = context;
    }

    public async Task<Author?> GetByEmailASync(string email)
    {
        return await _context.Authors.FirstOrDefaultAsync(a => a.Email == email);
    }
}