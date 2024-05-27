using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.DTOs.ProductAttributes.Capacity
{
	public class CreateCapacityRequestDto : ICreateBaseEntityRequestDto
	{
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public bool IsEnabled { get; set; }
		[Required]
		public int Capacity { get; set; }
	}
}
