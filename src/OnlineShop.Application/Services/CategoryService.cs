using OnlineShop.Application.DTOs.Categories;
using OnlineShop.Application.Interfaces.Categories;
using OnlineShop.Application.Mappers;

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

		public async Task<List<CategoryDto>> GetAllAsync()
		{
			var categories = await _categoryRepository.GetAllAsync();
			var categoriesToDTO = categories.Select(p => p.ToCategoryDTO()).ToList();
			return categoriesToDTO;
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
