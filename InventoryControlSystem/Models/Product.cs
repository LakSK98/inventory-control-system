using System.ComponentModel.DataAnnotations;

namespace InventoryControlSystem.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public virtual ProductCategory Category { get; set; }
    }
}
