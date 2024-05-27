using OnlineShop.Application.DTOs.Brands;
using OnlineShop.Application.Interfaces.BaseEntities;

namespace OnlineShop.Application.Interfaces.Brands
{
    public interface IBrandService : IBaseService<BrandDto, CreateBrandRequestDto>
	{
	}
}
