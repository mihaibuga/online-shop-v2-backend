namespace OnlineShop.Application.DTOs.Stocks
{
	public class StockDto : IBaseEntityDto
	{
		public Guid Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public bool IsEnabled { get; set; }
		public Guid ProductVariantId { get; set; }
		public int Quantity { get; set; }
	}
}
