using OnlineShop.Application.DTOs.Brands;
using OnlineShop.Application.Helpers.QueryObjects;
using OnlineShop.Application.Interfaces.Brands;
using OnlineShop.Application.Mappers;
using OnlineShop.Application.Wrappers;

namespace OnlineShop.Application.Services
{
	public class BrandService : IBrandService
	{
		private readonly IBrandRepository _brandRepository;

		public BrandService(IBrandRepository brandRepository)
		{
			_brandRepository = brandRepository;
		}

		public async Task<BrandDto> CreateAsync(CreateBrandRequestDto brandDto)
		{
			var brandModel = brandDto.ToBrandFromCreateDTO();

			await _brandRepository.CreateAsync(brandModel);

			return brandModel.ToBrandDTO();
		}

		public async Task<BrandDto?> DeleteAsync(Guid id)
		{
			var existingBrand = await _brandRepository.DeleteAsync(id);
			return existingBrand != null ? existingBrand.ToBrandDTO() : null;
		}

		public Task<PagedResponse<IQueryable<BrandDto>>> GetAllAsync(QueryObject query)
		{
			//var brands = await _brandRepository.GetAllAsync(query);
			//var brandsToDTO = brands.Select(b => b.ToBrandDTO()).ToList();
			//return brandsToDTO;

            throw new NotImplementedException();
        }

		public async Task<BrandDto?> GetByIdAsync(Guid id)
		{
			var existingBrand = await _brandRepository.GetByIdAsync(id);
			return existingBrand != null ? existingBrand.ToBrandDTO() : null;
		}

		public Task<BrandDto> UpdateAsync()
		{
			throw new NotImplementedException();
		}
	}
}
