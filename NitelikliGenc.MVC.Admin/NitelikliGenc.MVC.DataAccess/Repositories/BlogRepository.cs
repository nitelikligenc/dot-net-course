using Microsoft.EntityFrameworkCore;
using NitelikliGenc.MVC.Entities.Entities;

namespace NitelikliGenc.MVC.DataAccess.Repositories;

public class BlogRepository: GenericRepository<Blog>, IBlogRepository
{
    private readonly DataContext _context;

    public BlogRepository(DataContext context): base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Blog>> GetAllAsync()
    {
        return await _context.Blogs.Include(b => b.Category).ToListAsync();
    }
}