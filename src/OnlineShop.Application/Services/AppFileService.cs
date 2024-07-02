using Microsoft.Extensions.Options;
using OnlineShop.Application.DTOs.AppFiles;
using OnlineShop.Application.Helpers;
using OnlineShop.Application.Interfaces.Files;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Services
{
    public class AppFileService : IAppFileService
    {
        private readonly string _storagePath;
        private readonly IAppFileRepository _appFileRepository;

        public AppFileService(IOptions<FileStorageOptions> options, IAppFileRepository appFileRepository)
        {

            _storagePath = Path.Combine(Directory.GetCurrentDirectory(), options.Value.UploadPath);

            if (!Directory.Exists(_storagePath))
            {
                Directory.CreateDirectory(_storagePath);
            }

            _appFileRepository = appFileRepository;
        }

        public async Task<object> SaveFileAsync(FileAsset fileAsset)
        {
            try
            {
                var getFileValidationResult = new FileUploadHandler().Upload(fileAsset);

                if (getFileValidationResult != null && getFileValidationResult is AppFile)
                {
                    string? filePath = Path.Combine(_storagePath, ((AppFile)getFileValidationResult).CompleteFileName);

                    ((AppFile)getFileValidationResult).FileSourcePath = filePath;

                    using FileStream stream = new FileStream(filePath, FileMode.Create);
                    await fileAsset.File.CopyToAsync(stream);

                    await _appFileRepository.CreateAsync((AppFile)getFileValidationResult);

                    return getFileValidationResult;
                }

                return "There has been a problem saving the file";
            }
            catch (Exception e)
            {
                return e;
            }
        }

        public async Task<object> SaveFilesAsync(IList<FileAsset> fileAssets)
        {
            try
            {
                List<AppFile> appFiles = new List<AppFile>();

                foreach (var fileAsset in fileAssets)
                {
                    var newAppFile = await SaveFileAsync(fileAsset);

                    if (newAppFile != null && newAppFile is AppFile)
                    {
                        appFiles.Add((AppFile)newAppFile);
                    }
                }

                return appFiles;
            }
            catch (Exception e)
            {
                return e;
            }
        }
    }
}
