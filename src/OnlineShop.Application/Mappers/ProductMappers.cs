using OnlineShop.Application.DTOs.Products;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Mappers
{
	public static class ProductMappers
	{
		public static ProductDTO ToProductDTO(this Product productModel)
		{
			return new ProductDTO
			{
				Id = productModel.Id
			};
		}

		public static Product ToProductFromCreateDTO(this CreateProductRequestDTO productDTO)
		{
			return new Product();
		}
	}
}
