using OnlineShop.Application.DTOs.ProductVariants;
using OnlineShop.Application.Interfaces.BaseEntities;

namespace OnlineShop.Application.Interfaces.ProductVariants
{
    public interface IProductVariantService : IBaseService<ProductVariantDto, CreateProductVariantRequestDto>
	{
	}
}
