using System.ComponentModel.DataAnnotations;

namespace InventoryControlSystem.Models
{
    public class ProductCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public virtual List<Product> Products { get; set; }

    }
}
