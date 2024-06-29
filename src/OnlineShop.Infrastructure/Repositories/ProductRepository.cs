using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Helpers.QueryObjects;
using OnlineShop.Application.Interfaces.Products;
using OnlineShop.Application.Wrappers;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.Users;
using OnlineShop.Infrastructure.Data;

namespace OnlineShop.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product productModel)
        {
            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<PagedResponse<IQueryable<Product>>> GetAllAsync(QueryObject query)
        {
            var products = _context.Products.AsQueryable();

            //Sort products
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    products = query.IsAscending ? products.OrderBy(p => p.Name) : products.OrderByDescending(p => p.Name);
                }
                else
                {
                    products = products.OrderBy(p => p.Name);
                }
            }

            //Paginate users
            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            var pagedUsers = products.Skip(skipNumber).Take(query.PageSize);

            //Create paginated response
            var response = new PagedResponse<IQueryable<Product>>(pagedUsers, query.PageNumber, query.PageSize);

            var totalProducts = await _context.Products.CountAsync();
            response.TotalRecords = totalProducts;

            var totalPages = ((double)totalProducts / (double)query.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            response.TotalPages = roundedTotalPages;

            response.IsNextPage = response.PageNumber >= 1 && response.PageNumber < roundedTotalPages;
            response.IsPreviousPage = response.PageNumber - 1 >= 1 && response.PageNumber <= roundedTotalPages;

            return response;
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _context.Products
                    .FirstOrDefaultAsync(product => product.Id == id);
        }

        public Task<Product> UpdateAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Product?> DeleteAsync(Guid id)
        {
            var existingProduct = await _context.Products
                    .FirstOrDefaultAsync(product => product.Id == id);

            if (existingProduct == null)
            {
                return null;
            }

            _context.Products.Remove(existingProduct);
            await _context.SaveChangesAsync();

            return existingProduct;
        }
    }
}
