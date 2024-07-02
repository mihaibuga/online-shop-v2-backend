using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace OnlineShop.Application.DTOs.Products
{
    public class CreateProductRequestDto
	{
		[Required]
		public string Name { get; set; } = string.Empty;
		public string? Description { get; set; }

		[Required]
		public decimal Price { get; set; }
		public IEnumerable<IFormFile>? ProductImages { get; set; }
    }
}
