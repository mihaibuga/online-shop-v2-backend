using Microsoft.AspNetCore.Http;
using OnlineShop.Application.DTOs.AppFiles;
using OnlineShop.Application.DTOs.Products;

namespace OnlineShop.Application.Mappers
{
    public static class FileMappers
    {
        public static List<FileAsset> ToFileAssetList(this IEnumerable<IFormFile> formFiles)
        {
            var fileAssets = new List<FileAsset>();

            if (formFiles != null && formFiles.ToList().Count > 0)
            {
                foreach (var formFile in formFiles)
                {
                    FileAsset fileAsset = new()
                    {
                        File = formFile
                    };
                    fileAssets.Add(fileAsset);
                }
            }

            return fileAssets;
        }
    }
}
