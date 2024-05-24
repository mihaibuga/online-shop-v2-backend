using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Entities.ProductAttributes
{
    [Table("ProductAttributes")]
    public abstract class ProductAttribute : BaseEntity
	{
		public Guid? ProductVariantId { get; set; }
		public string MachineName { get; set; } = string.Empty;
		public string DisplayName { get; set; } = string.Empty;
		public abstract string Value { get; }
		public ProductVariant? ProductVariant { get; set; }
    }
}
