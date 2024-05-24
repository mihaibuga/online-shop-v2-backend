using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Entities
{
	[Table("Products")]
	public class Product : BaseEntity
	{
		public string Name { get; set; } = string.Empty;
		public string? Description { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal? PreviousPrice { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal Price { get; set; }

		public Guid? CategoryId { get; set; }
		public Guid? BrandId { get; set; }

		public Category? Category { get; set; }
		public Brand? Brand { get; set; }
		public ICollection<ProductVariant>? Variants { get; set; }
	}
}
