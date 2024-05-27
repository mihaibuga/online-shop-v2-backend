using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.DTOs.ProductAttributes.ScreenSize
{
	public class CreateScreenSizeRequestDto : ICreateBaseEntityRequestDto
	{
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public bool IsEnabled { get; set; }
		[Required]
		public double ScreenSize { get; set; }
	}
}
