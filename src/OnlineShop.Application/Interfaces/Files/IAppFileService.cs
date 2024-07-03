using OnlineShop.Application.DTOs.AppFiles;
using OnlineShop.Application.Helpers.QueryObjects;
using OnlineShop.Application.Wrappers;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Interfaces.Files
{
    public interface IAppFileService
    {
        Task<object> SaveFileAsync(FileAsset file);
        Task<object> SaveFilesAsync(IList<FileAsset> fileAssets);
        Task<PagedResponse<IQueryable<AppFile>>> GetAllAsync(QueryObject query);
    }
}
