namespace OnlineShop.Application.DTOs.Products
{
	public class ProductDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string? Description { get; set; }
		public decimal? PreviousPrice { get; set; }
		public decimal Price { get; set; }
	}
}
