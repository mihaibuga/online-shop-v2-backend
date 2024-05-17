using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Interfaces.Products
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product productModel);
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(Guid id);
        Task<Product> UpdateAsync();
        Task<Product?> DeleteAsync(Guid id);
    }
}
