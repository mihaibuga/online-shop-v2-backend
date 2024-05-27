using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces.Brands;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Data;


namespace OnlineShop.Infrastructure.Repositories
{
	public class BrandRepository : IBrandRepository
	{
		private readonly ApplicationDbContext _context;

		public BrandRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Brand> CreateAsync(Brand model)
		{
			await _context.Brands.AddAsync(model);
			await _context.SaveChangesAsync();
			return model;
		}

		public async Task<Brand?> DeleteAsync(Guid id)
		{
			var existingBrand = await _context.Brands
					.FirstOrDefaultAsync(brand => brand.Id == id);

			if (existingBrand == null)
			{
				return null;
			}

			_context.Brands.Remove(existingBrand);
			await _context.SaveChangesAsync();

			return existingBrand;
		}

		public async Task<List<Brand>> GetAllAsync()
		{
			return await _context.Brands.ToListAsync();
		}

		public async Task<Brand?> GetByIdAsync(Guid id)
		{
			return await _context.Brands
					.FirstOrDefaultAsync(brand => brand.Id == id);
		}

		public Task<Brand> UpdateAsync()
		{
			throw new NotImplementedException();
		}
	}
}
