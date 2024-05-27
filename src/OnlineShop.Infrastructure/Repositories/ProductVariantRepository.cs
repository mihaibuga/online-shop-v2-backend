using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces.ProductVariants;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Data;

namespace OnlineShop.Infrastructure.Repositories
{
	public class ProductVariantRepository : IProductVariantRepository
	{
		private readonly ApplicationDbContext _context;

		public ProductVariantRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<ProductVariant> CreateAsync(ProductVariant model)
		{
			await _context.ProductVariants.AddAsync(model);
			await _context.SaveChangesAsync();
			return model;
		}

		public async Task<ProductVariant?> DeleteAsync(Guid id)
		{
			var existingProductVariant = await _context.ProductVariants
					.FirstOrDefaultAsync(pv => pv.Id == id);

			if (existingProductVariant == null)
			{
				return null;
			}

			_context.ProductVariants.Remove(existingProductVariant);
			await _context.SaveChangesAsync();

			return existingProductVariant;
		}

		public async Task<List<ProductVariant>> GetAllAsync()
		{
			return await _context.ProductVariants.ToListAsync();
		}

		public async Task<ProductVariant?> GetByIdAsync(Guid id)
		{
			return await _context.ProductVariants
					.FirstOrDefaultAsync(pv => pv.Id == id);
		}

		public Task<ProductVariant> UpdateAsync()
		{
			throw new NotImplementedException();
		}
	}
}
