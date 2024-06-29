using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Application.DTOs.AppFiles;
using OnlineShop.Domain.Entities.Users;

namespace OnlineShop.Application.Helpers
{
    public class FileUploadHandler
    {
        public string Upload(FileAsset fileAsset)
        {
            //extension
            List<string> validExtensions = new List<string>() { ".jpg", ".png", ".gif", ".pdf" };

            string extension = Path.GetExtension(fileAsset.File.FileName);

            if (!validExtensions.Contains(extension))
            {
                return $"Extension is not among the valid extensions ({string.Join(',', validExtensions)})";
            }

            //file size
            long size = fileAsset.File.Length;
            int fileSizeMaxLimitMb = 5;
            var fileSizeLimitKb = fileSizeMaxLimitMb * 1024;
            var fileSizeLimitBytes = fileSizeLimitKb * 1024;

            if (size > fileSizeLimitBytes)
            {
                return $"Maximum size can be {fileSizeMaxLimitMb}mb";
            }

            //name changing
            string fileName = Guid.NewGuid().ToString() + extension;
            if (!String.IsNullOrEmpty(fileAsset.FileName))
            {
                fileName = fileAsset.FileName + extension;
            }

            return fileName;
        }
    }
}
