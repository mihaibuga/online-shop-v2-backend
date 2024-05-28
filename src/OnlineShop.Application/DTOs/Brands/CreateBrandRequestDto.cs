using System.ComponentModel.DataAnnotations;
using OnlineShop.Application.DTOs.BaseEntities;

namespace OnlineShop.Application.DTOs.Brands
{
    public class CreateBrandRequestDto : ICreateBaseEntityRequestDto
	{
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime? ModifiedDate { get; set; } = DateTime.Now;
		public bool IsEnabled { get; set; } = true;
		[Required]
		public string Name { get; set; } = string.Empty;
		public string? Description { get; set; }
	}
}
