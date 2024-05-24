using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Entities
{
	[Table("Stocks")]
	public class Stock : BaseEntity
	{
		public Guid ProductVariantId { get; set; }
		public int Quantity { get; set; }

		public ProductVariant? ProductVariant { get; set; }
	}
}
