using OnlineShop.Application.Helpers.QueryObjects;
using OnlineShop.Application.Wrappers;

namespace OnlineShop.Application.Interfaces.BaseEntities
{
    public interface IBaseRepository<T>
    {
        Task<T> CreateAsync(T model);
        Task<PagedResponse<IQueryable<T>>> GetAllAsync(QueryObject query);
        Task<T?> GetByIdAsync(Guid id);
        Task<T> UpdateAsync(T model);
        Task<T?> DeleteAsync(Guid id);
    }
}
