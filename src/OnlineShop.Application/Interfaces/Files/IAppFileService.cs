using OnlineShop.Application.DTOs.AppFiles;

namespace OnlineShop.Application.Interfaces.Files
{
    public interface IAppFileService
    {
        Task<string> SaveFileAsync(FileAsset file);
    }
}
