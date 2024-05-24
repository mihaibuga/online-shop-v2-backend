namespace OnlineShop.Domain.Entities.ProductAttributes
{
	public class ConditionAttribute : ProductAttribute
	{
		public string Condition { get; set; } = string.Empty;
		public override string Value => Condition;
	}
}
