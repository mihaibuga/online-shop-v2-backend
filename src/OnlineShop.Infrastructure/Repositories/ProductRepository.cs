using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces.Products;
using OnlineShop.Domain.Entities;
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

		public async Task<List<Product>> GetAllAsync()
		{
			return await _context.Products.ToListAsync();
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
