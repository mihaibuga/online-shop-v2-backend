namespace OnlineShop.Application.DTOs.ProductAttributes.Condition
{
	public class ConditionDto : IBaseEntityDto
	{
		public Guid Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public bool IsEnabled { get; set; }
		public string Condition { get; set; } = string.Empty;
	}
}
