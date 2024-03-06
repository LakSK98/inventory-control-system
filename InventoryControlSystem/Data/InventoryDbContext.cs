using InventoryControlSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryControlSystem.Data
{
    public class InventoryDbContext: DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
