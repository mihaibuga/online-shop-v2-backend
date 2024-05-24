using OnlineShop.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Entities
{
	[Table("StockInventoryTransactions")]
	public class InventoryTransaction : BaseEntity
	{
		public Guid ProductVariantId { get; set; }
		public DateTime TransactionDate { get; set; }
		public TransactionType Type { get; set; }
		public int Quantity { get; set; }
		public string? Description { get; set; }

		public ProductVariant? ProductVariant { get; set; }
	}
}
