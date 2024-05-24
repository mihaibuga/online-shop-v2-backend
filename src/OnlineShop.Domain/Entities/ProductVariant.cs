using OnlineShop.Domain.Entities.ProductAttributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Entities
{
	[Table("ProductVariants")]
	public class ProductVariant : BaseEntity
	{
		public Guid? ProductId { get; set; }
		public Product? Product { get; set; }
		public Stock? Stock { get; set; }
		public ICollection<ProductAttribute>? Attributes { get; set; }
		public ICollection<InventoryTransaction>? InventoryTransactions { get; set; }
	}
}
