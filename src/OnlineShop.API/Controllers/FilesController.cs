using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTOs.AppFiles;
using OnlineShop.Application.Interfaces.Files;
using OnlineShop.Domain.Entities.Users;

namespace OnlineShop.API.Controllers
{
    [Route("api/files")]
    public class FilesController : ApiControllerBase
    {
        private readonly IAppFileService _appFileService;
        private readonly IWebHostEnvironment _env;

        public FilesController(IAppFileService appFileService, IWebHostEnvironment env)
        {
            _appFileService = appFileService;
            _env = env;
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UploadFile([FromForm] FileAsset fileAsset)
        {
            var savedFile = await _appFileService.SaveFileAsync(fileAsset);

            return Ok(savedFile);
        }
    }
}
