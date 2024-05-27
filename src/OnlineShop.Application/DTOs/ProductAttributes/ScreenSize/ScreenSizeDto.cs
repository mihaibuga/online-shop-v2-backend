namespace OnlineShop.Application.DTOs.ProductAttributes.ScreenSize
{
	public class ScreenSizeDto : IBaseEntityDto
	{
		public Guid Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public bool IsEnabled { get; set; }
		public double ScreenSize { get; set; }
	}
}
