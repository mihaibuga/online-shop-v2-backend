using System.ComponentModel.DataAnnotations;
using OnlineShop.Application.DTOs.BaseEntities;

namespace OnlineShop.Application.DTOs.ProductAttributes.ScreenSize
{
    public class CreateScreenSizeRequestDto : ICreateBaseEntityRequestDto
	{
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime? ModifiedDate { get; set; } = DateTime.Now;
		public bool IsEnabled { get; set; } = true;
		[Required]
		public double ScreenSize { get; set; }
	}
}
