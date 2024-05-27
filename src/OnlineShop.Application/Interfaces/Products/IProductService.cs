using OnlineShop.Application.DTOs.Products;
using OnlineShop.Application.Interfaces.BaseEntities;

namespace OnlineShop.Application.Interfaces.Products
{
    public interface IProductService : IBaseService<ProductDto, CreateProductRequestDto>
	{
    }
}
