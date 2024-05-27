using OnlineShop.Application.DTOs.Categories;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Mappers
{
	public static class CategoryMappers
	{
		public static CategoryDto ToCategoryDTO(this Category categoryModel)
		{
			return new CategoryDto
			{
				Id = categoryModel.Id,
				CreatedDate = categoryModel.CreatedDate,
				ModifiedDate = categoryModel.ModifiedDate,
				IsEnabled = categoryModel.IsEnabled,
				Name = categoryModel.Name,
				Description = categoryModel.Description,
			};
		}

		public static Category ToCategoryFromCreateDTO(this CreateCategoryRequestDto categoryDTO)
		{
			return new Category
			{
				CreatedDate = categoryDTO.CreatedDate,
				ModifiedDate = categoryDTO.ModifiedDate,
				IsEnabled = categoryDTO.IsEnabled,
				Name = categoryDTO.Name,
				Description = categoryDTO.Description,
			};
		}
	}
}
