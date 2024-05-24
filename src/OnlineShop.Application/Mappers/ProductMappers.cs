using OnlineShop.Application.DTOs.Products;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Mappers
{
	public static class ProductMappers
	{
		public static ProductDto ToProductDTO(this Product productModel)
		{
			return new ProductDto
			{
				Id = productModel.Id,
				Name = productModel.Name,
				Description = productModel.Description,
				PreviousPrice = productModel.PreviousPrice,
				Price = productModel.Price,
			};
		}

		public static Product ToProductFromCreateDTO(this CreateProductRequestDto productDTO)
		{
			return new Product
			{
				Name = productDTO.Name,
				Description = productDTO.Description,
				PreviousPrice = productDTO.PreviousPrice,
				Price = productDTO.Price
			};
		}
	}
}
