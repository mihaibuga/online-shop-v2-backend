using Microsoft.AspNetCore.Http;
using OnlineShop.Application.DTOs.AppFiles;
using OnlineShop.Application.Interfaces.BaseEntities;

namespace OnlineShop.Application.Interfaces.Files
{
    public interface IAppFileService
    {
        Task<string> SaveFileAsync(IFormFile file);
    }
}
