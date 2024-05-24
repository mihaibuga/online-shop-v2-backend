namespace OnlineShop.Domain.Entities.ProductAttributes
{
	public class CapacityAttribute : ProductAttribute
	{
		public int Capacity { get; set; }
		public override string Value => Capacity.ToString();
	}
}
