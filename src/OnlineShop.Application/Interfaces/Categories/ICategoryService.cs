using OnlineShop.Application.DTOs.Categories;
using OnlineShop.Application.Interfaces.BaseEntities;

namespace OnlineShop.Application.Interfaces.Categories
{
    public interface ICategoryService : IBaseService<CategoryDto, CreateCategoryRequestDto>
	{
	}
}
