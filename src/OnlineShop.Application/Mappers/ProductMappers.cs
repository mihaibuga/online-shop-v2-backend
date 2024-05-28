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
				CreatedDate = productModel.CreatedDate,
				ModifiedDate = productModel.ModifiedDate,
				IsEnabled = productModel.IsEnabled,
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
				CreatedDate = productDTO.CreatedDate,
				ModifiedDate = productDTO.ModifiedDate,
				IsEnabled = productDTO.IsEnabled,
				Name = productDTO.Name,
				Description = productDTO.Description,
				PreviousPrice = productDTO.PreviousPrice,
				Price = productDTO.Price
			};
		}
	}
}
