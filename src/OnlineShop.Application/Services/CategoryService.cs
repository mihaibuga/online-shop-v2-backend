using OnlineShop.Application.DTOs.Categories;
using OnlineShop.Application.Helpers.QueryObjects;
using OnlineShop.Application.Interfaces.Categories;
using OnlineShop.Application.Mappers;
using OnlineShop.Application.Wrappers;

namespace OnlineShop.Application.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoryService(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task<CategoryDto> CreateAsync(CreateCategoryRequestDto categoryDTO)
		{
			var categoryModel = categoryDTO.ToCategoryFromCreateDTO();

			await _categoryRepository.CreateAsync(categoryModel);

			return categoryModel.ToCategoryDTO();
		}

		public async Task<CategoryDto?> DeleteAsync(Guid id)
		{
			var existingCategory = await _categoryRepository.DeleteAsync(id);
			return existingCategory != null ? existingCategory.ToCategoryDTO() : null;
		}

		public Task<PagedResponse<IQueryable<CategoryDto>>> GetAllAsync(QueryObject query)
		{
            //var categories = await _categoryRepository.GetAllAsync(query);
            //var categoriesToDTO = categories.Select(p => p.ToCategoryDTO()).ToList();
            //return categoriesToDTO;

            throw new NotImplementedException();
        }

		public async Task<CategoryDto?> GetByIdAsync(Guid id)
		{
			var existingCategory = await _categoryRepository.GetByIdAsync(id);
			return existingCategory != null ? existingCategory.ToCategoryDTO() : null;
		}

		public Task<CategoryDto> UpdateAsync()
		{
			throw new NotImplementedException();
		}
	}
}
