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

		public async Task<ProductDTO> CreateAsync(CreateProductRequestDTO productDTO)
		{
			var productModel = productDTO.ToProductFromCreateDTO();

			await _productRepository.CreateAsync(productModel);

			return productModel.ToProductDTO();
		}

		public async Task<List<ProductDTO>> GetAllAsync()
		{
			var products = await _productRepository.GetAllAsync();
			var productsToDTO = products.Select(m => m.ToProductDTO()).ToList();
			return productsToDTO;
		}

		public async Task<ProductDTO?> GetByIdAsync(Guid id)
		{
			var existingProduct = await _productRepository.GetByIdAsync(id);
			return existingProduct != null ? existingProduct.ToProductDTO() : null;
		}

		public Task<ProductDTO> UpdateAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<ProductDTO?> DeleteAsync(Guid id)
		{
			var existingProduct = await _productRepository.DeleteAsync(id);
			return existingProduct != null ? existingProduct.ToProductDTO() : null;
		}
	}
}
