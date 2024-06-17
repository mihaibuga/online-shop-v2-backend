using Microsoft.AspNetCore.Http;

namespace OnlineShop.Application.Helpers
{
    public class FileUploadHandler
    {
        public string Upload(IFormFile file)
        {
            //extension
            List<string> validExtensions = new List<string>() { ".jpg", ".png", ".gif", ".pdf" };

            string extension = Path.GetExtension(file.FileName);

            if (!validExtensions.Contains(extension))
            {
                return $"Extension is not among the valid extensions ({string.Join(',', validExtensions)})";
            }

            //file size
            long size = file.Length;
            int fileSizeMaxLimitMb = 5;
            var fileSizeLimitKb = fileSizeMaxLimitMb * 1024;
            var fileSizeLimitBytes = fileSizeLimitKb * 1024;

            if (size > fileSizeLimitBytes)
            {
                return $"Maximum size can be {fileSizeMaxLimitMb}mb";
            }

            //name changing
            string fileName = Guid.NewGuid().ToString() + extension;

            return fileName;
        }
    }
}
