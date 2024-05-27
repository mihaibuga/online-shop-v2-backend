using OnlineShop.Application.DTOs.ProductVariants;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Mappers
{
	public static class ProductVariantMappers
	{
		public static ProductVariantDto ToProductVariantDTO(this ProductVariant productVariantModel)
		{
			return new ProductVariantDto
			{
				Id = productVariantModel.Id,
				CreatedDate = productVariantModel.CreatedDate,
				ModifiedDate = productVariantModel.ModifiedDate,
				IsEnabled = productVariantModel.IsEnabled,
				ProductId = productVariantModel.ProductId,
			};
		}

		public static ProductVariant ToProductVariantFromCreateDTO(this CreateProductVariantRequestDto productVariantDTO)
		{
			return new ProductVariant
			{
				CreatedDate = productVariantDTO.CreatedDate,
				ModifiedDate = productVariantDTO.ModifiedDate,
				IsEnabled = productVariantDTO.IsEnabled,
				ProductId = productVariantDTO.ProductId,
			};
		}
	}
}
