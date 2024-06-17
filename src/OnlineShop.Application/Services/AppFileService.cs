using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using OnlineShop.Application.Helpers;
using OnlineShop.Application.Interfaces.Files;

namespace OnlineShop.Application.Services
{
    public class AppFileService : IAppFileService
    {
        private readonly string _storagePath;

        public AppFileService(IOptions<FileStorageOptions> options)
        {

            _storagePath = Path.Combine(Directory.GetCurrentDirectory(), options.Value.UploadPath);

            if (!Directory.Exists(_storagePath))
            {
                Directory.CreateDirectory(_storagePath);
            }
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            try
            {
                var getValidFileName = new FileUploadHandler().Upload(file);
                var filePath = Path.Combine(_storagePath, getValidFileName);

                using FileStream stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);

                return getValidFileName;
            }
            catch
            {
                return "There has been a problem saving the file";
            }
        }
    }
}
