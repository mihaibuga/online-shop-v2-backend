using OnlineShop.Application.DTOs.BaseEntities;

namespace OnlineShop.Application.DTOs.ProductAttributes.Color
{
    public class ColorDto : IBaseEntityDto
	{
		public Guid Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public bool IsEnabled { get; set; }
		public string Color { get; set; } = string.Empty;
	}
}
