using OnlineShop.Application.DTOs.BaseEntities;

namespace OnlineShop.Application.DTOs.Products
{
    public class ProductDto : IBaseEntityDto
	{
		public Guid Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public bool IsEnabled { get; set; }
		public string Name { get; set; } = string.Empty;
		public string? Description { get; set; }
		public decimal? PreviousPrice { get; set; }
		public decimal Price { get; set; }
	}
}
