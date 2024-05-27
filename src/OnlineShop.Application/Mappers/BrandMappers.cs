using OnlineShop.Application.DTOs.Brands;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Mappers
{
	public static class BrandMappers
	{
		public static BrandDto ToBrandDTO(this Brand brandModel)
		{
			return new BrandDto
			{
				Id = brandModel.Id,
				CreatedDate = brandModel.CreatedDate,
				ModifiedDate = brandModel.ModifiedDate,
				IsEnabled = brandModel.IsEnabled,
				Name = brandModel.Name,
				Description = brandModel.Description,
			};
		}

		public static Brand ToBrandFromCreateDTO(this CreateBrandRequestDto brandDTO)
		{
			return new Brand
			{
				CreatedDate = brandDTO.CreatedDate,
				ModifiedDate = brandDTO.ModifiedDate,
				IsEnabled = brandDTO.IsEnabled,
				Name = brandDTO.Name,
				Description = brandDTO.Description,
			};
		}
	}
}
