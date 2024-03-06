using InventoryControlSystem.Data;
using InventoryControlSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryControlSystem.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly InventoryDbContext _context;

        public ProductCategoryRepository(InventoryDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductCategory>> GetAllCategoriesAsync()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.ProductCategories.FindAsync(categoryId);
        }

        public async Task AddCategoryAsync(ProductCategory category)
        {
            _context.ProductCategories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(ProductCategory category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await _context.ProductCategories.FindAsync(categoryId);
            if (category != null)
            {
                _context.ProductCategories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
