using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.DTOs.Products;
using OnlineShop.Application.Helpers.QueryObjects;
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

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> CreateAsync(CreateProductRequestDto productDTO)
        {
            var productModel = productDTO.ToProductFromCreateDTO();

            await _productRepository.CreateAsync(productModel);

            return productModel.ToProductDTO();
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
