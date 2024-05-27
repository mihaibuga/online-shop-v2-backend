using OnlineShop.Application.DTOs.ProductVariants;
using OnlineShop.Application.Interfaces.ProductVariants;
using OnlineShop.Application.Mappers;

namespace OnlineShop.Application.Services
{
	public class ProductVariantService : IProductVariantService
	{
		private readonly IProductVariantRepository _productVariantRepository;

		public ProductVariantService(IProductVariantRepository productVariantRepository)
		{
			_productVariantRepository = productVariantRepository;
		}

		public async Task<ProductVariantDto> CreateAsync(CreateProductVariantRequestDto productVariantDTO)
		{
			var productVariantModel = productVariantDTO.ToProductVariantFromCreateDTO();

			await _productVariantRepository.CreateAsync(productVariantModel);

			return productVariantModel.ToProductVariantDTO();
		}

		public async Task<ProductVariantDto?> DeleteAsync(Guid id)
		{
			var existingProductVariant = await _productVariantRepository.DeleteAsync(id);
			return existingProductVariant != null ? existingProductVariant.ToProductVariantDTO() : null;
		}

		public async Task<List<ProductVariantDto>> GetAllAsync()
		{
			var productVariants = await _productVariantRepository.GetAllAsync();
			var productVariantsToDTO = productVariants.Select(pv => pv.ToProductVariantDTO()).ToList();
			return productVariantsToDTO;
		}

		public async Task<ProductVariantDto?> GetByIdAsync(Guid id)
		{
			var existingProductVariant = await _productVariantRepository.GetByIdAsync(id);
			return existingProductVariant != null ? existingProductVariant.ToProductVariantDTO() : null;
		}

		public Task<ProductVariantDto> UpdateAsync()
		{
			throw new NotImplementedException();
		}
	}
}
