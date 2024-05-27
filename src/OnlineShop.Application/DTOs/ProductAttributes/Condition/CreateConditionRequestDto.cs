using System.ComponentModel.DataAnnotations;
using OnlineShop.Application.DTOs.BaseEntities;

namespace OnlineShop.Application.DTOs.ProductAttributes.Condition
{
    public class CreateConditionRequestDto : ICreateBaseEntityRequestDto
	{
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public bool IsEnabled { get; set; }
		[Required]
		public string Condition { get; set; } = string.Empty;
	}
}
