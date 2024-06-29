using OnlineShop.Application.Helpers.QueryObjects;
using OnlineShop.Application.Wrappers;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Interfaces.Files
{
    public interface IAppFileRepository
    {
        Task<AppFile> CreateAsync(AppFile fileModel);
        Task<PagedResponse<IQueryable<AppFile>>> GetAllAsync(QueryObject query);
        Task<AppFile?> GetByIdAsync(Guid id);
        Task<AppFile> UpdateAsync();
        Task<AppFile?> DeleteAsync(Guid id);
    }
}
