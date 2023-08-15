using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NitelikliGenc.MVC.Entities.Entities;

namespace NitelikliGenc.MVC.DataAccess;

public class DataContext : IdentityDbContext<User, Role, int>
{
    private IConfiguration _configuration { get; set; }

    public DataContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
    }
    
    public DbSet<About> Abouts { get; set; } 
    public DbSet<Author> Authors { get; set; } 
    public DbSet<Blog> Blogs { get; set; } 
    public DbSet<Comment> Comments { get; set; } 
    public DbSet<Contact> Contacts { get; set; } 
    public DbSet<Category> Categories { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        ProcessSaveChanges();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void ProcessSaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.ModifiedAt = DateTime.UtcNow;
                    break;
            }
        }
    }
}