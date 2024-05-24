namespace OnlineShop.Domain.Entities.ProductAttributes
{
	public class ScreenSizeAttribute : ProductAttribute
	{
		public double ScreenSize { get; set; }
		public override string Value => ScreenSize.ToString();
	}
}
