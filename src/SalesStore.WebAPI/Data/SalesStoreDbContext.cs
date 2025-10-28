using SalesStore.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesStore.WebAPI.Data;

public class SalesStoreDbContext : DbContext
{
    public SalesStoreDbContext(DbContextOptions<SalesStoreDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}