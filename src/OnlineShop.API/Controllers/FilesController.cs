using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTOs.Products;
using OnlineShop.Application.Interfaces.Files;
using OnlineShop.Application.Interfaces.Products;
using OnlineShop.Application.Services;

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
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var savedFile = await _appFileService.SaveFileAsync(file);

            return Ok(savedFile);
        }
    }
}
