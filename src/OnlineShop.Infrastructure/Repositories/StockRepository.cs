using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Helpers.QueryObjects;
using OnlineShop.Application.Interfaces.Stocks;
using OnlineShop.Application.Wrappers;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Data;

namespace OnlineShop.Infrastructure.Repositories
{
	public class StockRepository : IStockRepository
	{
		private readonly ApplicationDbContext _context;

		public StockRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Stock> CreateAsync(Stock model)
		{
			await _context.Stocks.AddAsync(model);
			await _context.SaveChangesAsync();
			return model;
		}

		public async Task<Stock?> DeleteAsync(Guid id)
		{
			var existingStock = await _context.Stocks
					.FirstOrDefaultAsync(s => s.Id == id);

			if (existingStock == null)
			{
				return null;
			}

			_context.Stocks.Remove(existingStock);
			await _context.SaveChangesAsync();

			return existingStock;
		}

		public Task<PagedResponse<IQueryable<Stock>>> GetAllAsync(QueryObject query)
		{
            //return await _context.Stocks.ToListAsync();
            throw new NotImplementedException();
        }

		public async Task<Stock?> GetByIdAsync(Guid id)
		{
			return await _context.Stocks
					.FirstOrDefaultAsync(s => s.Id == id);
		}

		public Task<Stock> UpdateAsync()
		{
			throw new NotImplementedException();
		}
	}
}
