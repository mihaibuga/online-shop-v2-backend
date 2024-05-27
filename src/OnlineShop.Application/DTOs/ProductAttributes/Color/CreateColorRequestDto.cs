using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.DTOs.ProductAttributes.Color
{
	public class CreateColorRequestDto : ICreateBaseEntityRequestDto
	{
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public bool IsEnabled { get; set; }
		[Required]
		public string Color { get; set; } = string.Empty;
	}
}
