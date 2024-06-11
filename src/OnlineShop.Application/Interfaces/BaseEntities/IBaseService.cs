using OnlineShop.Application.Helpers.QueryObjects;
using OnlineShop.Application.Wrappers;

namespace OnlineShop.Application.Interfaces.BaseEntities
{
    public interface IBaseService<TDto, CreateTRequestDto>
    {
        Task<TDto> CreateAsync(CreateTRequestDto baseEntityDto);
        Task<PagedResponse<IQueryable<TDto>>> GetAllAsync(QueryObject query);
        Task<TDto?> GetByIdAsync(Guid id);
        Task<TDto> UpdateAsync();
        Task<TDto?> DeleteAsync(Guid id);
    }
}
