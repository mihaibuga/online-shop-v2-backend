using System.ComponentModel.DataAnnotations;
using OnlineShop.Application.DTOs.BaseEntities;

namespace OnlineShop.Application.DTOs.ProductAttributes.Capacity
{
    public class CreateCapacityRequestDto : ICreateBaseEntityRequestDto
	{
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime? ModifiedDate { get; set; } = DateTime.Now;
		public bool IsEnabled { get; set; } = true;
		[Required]
		public int Capacity { get; set; }
	}
}
