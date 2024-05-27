namespace OnlineShop.Application.DTOs.Stocks
{
	public class CreateStockRequestDto : ICreateBaseEntityRequestDto
	{
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public bool IsEnabled { get; set; }
		public Guid ProductVariantId { get; set; }
		public int Quantity { get; set; }
	}
}
