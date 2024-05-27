using OnlineShop.Application.DTOs.BaseEntities;

namespace OnlineShop.Application.DTOs.ProductVariants
{
    public class ProductVariantDto : IBaseEntityDto
	{
		public Guid Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public bool IsEnabled { get; set; }
		public Guid? ProductId { get; set; }
	}
}
