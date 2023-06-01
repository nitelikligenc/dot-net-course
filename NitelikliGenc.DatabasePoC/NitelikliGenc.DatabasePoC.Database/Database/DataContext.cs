using Microsoft.EntityFrameworkCore;
using NitelikliGenc.DatabasePoC.Database.Models;

namespace NitelikliGenc.DatabasePoC.Database.Database;

public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=sa;Database=DotnetCourse");

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}