using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces.Categories;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Data;

namespace OnlineShop.Infrastructure.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly ApplicationDbContext _context;

		public CategoryRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Category> CreateAsync(Category model)
		{
			await _context.Categories.AddAsync(model);
			await _context.SaveChangesAsync();
			return model;
		}

		public async Task<Category?> DeleteAsync(Guid id)
		{
			var existingCategory = await _context.Categories
					.FirstOrDefaultAsync(category => category.Id == id);

			if (existingCategory == null)
			{
				return null;
			}

			_context.Categories.Remove(existingCategory);
			await _context.SaveChangesAsync();

			return existingCategory;
		}

		public async Task<List<Category>> GetAllAsync()
		{
			return await _context.Categories.ToListAsync();
		}

		public async Task<Category?> GetByIdAsync(Guid id)
		{
			return await _context.Categories
					.FirstOrDefaultAsync(category => category.Id == id);
		}

		public Task<Category> UpdateAsync()
		{
			throw new NotImplementedException();
		}
	}
}
