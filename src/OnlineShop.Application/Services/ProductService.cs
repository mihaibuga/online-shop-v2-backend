using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.DTOs.AppFiles;
using OnlineShop.Application.DTOs.Products;
using OnlineShop.Application.Helpers.QueryObjects;
using OnlineShop.Application.Interfaces.Files;
using OnlineShop.Application.Interfaces.Products;
using OnlineShop.Application.Mappers;
using OnlineShop.Application.Wrappers;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Services
{
    //Implement Bussiness Rule / USE CASES
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IAppFileService _appFileService;

        public ProductService(IProductRepository productRepository, IAppFileService appFileService)
        {
            _productRepository = productRepository;
            _appFileService = appFileService;
        }

        public async Task<ProductDto> CreateAsync(CreateProductRequestDto productDTO)
        {
            var productModel = productDTO.ToProductFromCreateDTO();

            var newProduct = await _productRepository.CreateAsync(productModel);

            await AddProductImagesAsync(productDTO.ProductImages, newProduct.Id);

            return productModel.ToProductDTO();
        }

        public async Task<List<ProductImage>> AddProductImagesAsync(IEnumerable<IFormFile> productImageFormFiles, Guid productId)
        {
            if (productImageFormFiles != null)
            {
                var existingProduct = await _productRepository.GetByIdAsync(productId);

                if (existingProduct != null)
                {
                    List<FileAsset> mappedFileAssets = productImageFormFiles.ToFileAssetList();

                    if (mappedFileAssets.Count != 0)
                    {
                        var savedAppFiles = await _appFileService.SaveFilesAsync(mappedFileAssets);

                        if (savedAppFiles != null && savedAppFiles is List<AppFile>)
                        {
                            List<ProductImage> productImages = ((List<AppFile>)savedAppFiles).ToProductImagesList(productId);

                            existingProduct.ProductImages = productImages;

                            await _productRepository.UpdateAsync(existingProduct);
                        }
                    }
                }
            }

            return new List<ProductImage>();
        }

        public async Task<PagedResponse<IQueryable<ProductDto>>> GetAllAsync(QueryObject query)
        {
            var response = await _productRepository.GetAllAsync(query);
            var responseDataAsList = await response.Data.ToListAsync();
            var mappedList = responseDataAsList.Select(p => p.ToProductDTO()).ToList();
            var newData = mappedList.AsQueryable();

            var newResponse = new PagedResponse<IQueryable<ProductDto>>(newData, response.PageNumber, response.PageSize);
            newResponse.TotalRecords = response.TotalRecords;
            newResponse.TotalPages = response.TotalPages;
            newResponse.IsNextPage = response.IsNextPage;
            newResponse.IsPreviousPage = response.IsPreviousPage;

            return newResponse;
        }

        public async Task<ProductDto?> GetByIdAsync(Guid id)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            return existingProduct != null ? existingProduct.ToProductDTO() : null;
        }

        public Task<ProductDto> UpdateAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDto?> DeleteAsync(Guid id)
        {
            var existingProduct = await _productRepository.DeleteAsync(id);
            return existingProduct != null ? existingProduct.ToProductDTO() : null;
        }
    }
}
