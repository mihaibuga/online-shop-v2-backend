using OnlineShop.Application.DTOs.BaseEntities;

namespace OnlineShop.Application.DTOs.ProductVariants
{
    public class CreateProductVariantRequestDto : ICreateBaseEntityRequestDto
	{
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public bool IsEnabled { get; set; }
		public Guid? ProductId { get; set; }
	}
}
