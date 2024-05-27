﻿using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces.InventoryTransactions;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Data;

namespace OnlineShop.Infrastructure.Repositories
{
	public class InventoryTransactionRepository : IInventoryTransactionRepository
	{
		private readonly ApplicationDbContext _context;

		public InventoryTransactionRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<InventoryTransaction> CreateAsync(InventoryTransaction model)
		{
			await _context.StockInventoryTransactions.AddAsync(model);
			await _context.SaveChangesAsync();
			return model;
		}

		public async Task<InventoryTransaction?> DeleteAsync(Guid id)
		{
			var existingInventoryTransaction = await _context.StockInventoryTransactions
					.FirstOrDefaultAsync(it => it.Id == id);

			if (existingInventoryTransaction == null)
			{
				return null;
			}

			_context.StockInventoryTransactions.Remove(existingInventoryTransaction);
			await _context.SaveChangesAsync();

			return existingInventoryTransaction;
		}

		public async Task<List<InventoryTransaction>> GetAllAsync()
		{
			return await _context.StockInventoryTransactions.ToListAsync();
		}

		public async Task<InventoryTransaction?> GetByIdAsync(Guid id)
		{
			return await _context.StockInventoryTransactions
					.FirstOrDefaultAsync(it => it.Id == id);
		}

		public Task<InventoryTransaction> UpdateAsync()
		{
			throw new NotImplementedException();
		}
	}
}
