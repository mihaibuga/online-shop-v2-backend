using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.DTOs.Products
{
	public class CreateProductRequestDto
	{
		[Required]
		public string Name { get; set; } = string.Empty;
		public string? Description { get; set; }

		public decimal? PreviousPrice { get; set; }

		[Required]
		public decimal Price { get; set; }
	}
}
