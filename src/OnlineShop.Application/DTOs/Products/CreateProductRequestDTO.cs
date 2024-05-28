using System.ComponentModel.DataAnnotations;
using OnlineShop.Application.DTOs.BaseEntities;

namespace OnlineShop.Application.DTOs.Products
{
    public class CreateProductRequestDto : ICreateBaseEntityRequestDto
	{
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime? ModifiedDate { get; set; } = DateTime.Now;
		public bool IsEnabled { get; set; } = true;
		[Required]
		public string Name { get; set; } = string.Empty;
		public string? Description { get; set; }

		public decimal? PreviousPrice { get; set; }

		[Required]
		public decimal Price { get; set; }
	}
}
