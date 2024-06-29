using Microsoft.AspNetCore.Http;

namespace OnlineShop.Application.DTOs.AppFiles
{
    public class FileAsset
    {
        public IFormFile File { get; set; }
        public string? FileName { get; set; }
    }
}
