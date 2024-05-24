namespace OnlineShop.Domain.Entities.ProductAttributes
{
	public class ColorAttribute : ProductAttribute
	{
		public string Color { get; set; } = string.Empty;
		public override string Value => Color;
	}
}
