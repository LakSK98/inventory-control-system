using InventoryControlSystem.Models;

namespace InventoryControlSystem.Repository
{
    public interface IProductCategoryRepository
    {
        Task<List<ProductCategory>> GetAllCategoriesAsync();
        Task<ProductCategory> GetCategoryByIdAsync(int categoryId);
        Task AddCategoryAsync(ProductCategory category);
        Task UpdateCategoryAsync(ProductCategory category);
        Task DeleteCategoryAsync(int categoryId);
    }
}
