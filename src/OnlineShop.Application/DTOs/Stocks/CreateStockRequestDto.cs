using OnlineShop.Application.DTOs.BaseEntities;

namespace OnlineShop.Application.DTOs.Stocks
{
    public class CreateStockRequestDto : ICreateBaseEntityRequestDto
	{
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime? ModifiedDate { get; set; } = DateTime.Now;
		public bool IsEnabled { get; set; } = true;
		public Guid ProductVariantId { get; set; }
		public int Quantity { get; set; }
	}
}
