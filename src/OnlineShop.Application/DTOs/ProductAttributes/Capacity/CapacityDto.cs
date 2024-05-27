namespace OnlineShop.Application.DTOs.ProductAttributes.Capacity
{
	public class CapacityDto : IBaseEntityDto
	{
		public Guid Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public bool IsEnabled { get; set; }
		public int Capacity { get; set; }
	}
}
