using OnlineShop.Application.DTOs.Products;

namespace OnlineShop.Application.Interfaces.Products
{
    //This interface is used for Bussiness Rule / USE CASE
    public interface IProductService
    {
        Task<ProductDTO> CreateAsync(CreateProductRequestDTO productDTO);
        Task<List<ProductDTO>> GetAllAsync();
        Task<ProductDTO?> GetByIdAsync(Guid id);
        Task<ProductDTO> UpdateAsync();
        Task<ProductDTO?> DeleteAsync(Guid id);
    }
}
