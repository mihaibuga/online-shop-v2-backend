using OnlineShop.Application.DTOs.Products;
using OnlineShop.Application.Interfaces.Products;
using OnlineShop.Application.Mappers;

namespace OnlineShop.Application.Services
{
	//Implement Bussiness Rule / USE CASES
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task<ProductDto> CreateAsync(CreateProductRequestDto productDTO)
		{
			var productModel = productDTO.ToProductFromCreateDTO();

			await _productRepository.CreateAsync(productModel);

			return productModel.ToProductDTO();
		}

		public async Task<List<ProductDto>> GetAllAsync()
		{
			var products = await _productRepository.GetAllAsync();
			var productsToDTO = products.Select(p => p.ToProductDTO()).ToList();
			return productsToDTO;
		}

		public async Task<ProductDto?> GetByIdAsync(Guid id)
		{
			var existingProduct = await _productRepository.GetByIdAsync(id);
			return existingProduct != null ? existingProduct.ToProductDTO() : null;
		}

		public Task<ProductDto> UpdateAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<ProductDto?> DeleteAsync(Guid id)
		{
			var existingProduct = await _productRepository.DeleteAsync(id);
			return existingProduct != null ? existingProduct.ToProductDTO() : null;
		}
	}
}
