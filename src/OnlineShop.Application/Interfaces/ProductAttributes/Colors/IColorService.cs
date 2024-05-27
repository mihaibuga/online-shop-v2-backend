using OnlineShop.Application.DTOs.ProductAttributes.Color;
using OnlineShop.Application.Interfaces.BaseEntities;

namespace OnlineShop.Application.Interfaces.ProductAttributes.Colors
{
    public interface IColorService : IBaseService<ColorDto, CreateColorRequestDto>
	{
	}
}
