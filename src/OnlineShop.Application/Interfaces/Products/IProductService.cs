using OnlineShop.Application.DTOs.Products;

namespace OnlineShop.Application.Interfaces.Products
{
    //This interface is used for Bussiness Rule / USE CASE
    public interface IProductService
    {
        Task<ProductDto> CreateAsync(CreateProductRequestDto productDTO);
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(Guid id);
        Task<ProductDto> UpdateAsync();
        Task<ProductDto?> DeleteAsync(Guid id);
    }
}
