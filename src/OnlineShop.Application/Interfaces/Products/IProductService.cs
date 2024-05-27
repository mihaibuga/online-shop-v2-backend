using OnlineShop.Application.DTOs.Products;

namespace OnlineShop.Application.Interfaces.Products
{
    public interface IProductService : IBaseService<ProductDto, CreateProductRequestDto>
	{
    }
}
