using OnlineShop.Application.DTOs.InventoryTransactions;
using OnlineShop.Application.DTOs.Products;
using OnlineShop.Application.Helpers.QueryObjects;
using OnlineShop.Application.Interfaces.InventoryTransactions;
using OnlineShop.Application.Interfaces.Products;
using OnlineShop.Application.Mappers;
using OnlineShop.Application.Wrappers;

namespace OnlineShop.Application.Services
{
	public class InventoryTransactionService : IInventoryTransactionService
	{
		private readonly IInventoryTransactionRepository _inventoryTransactionRepository;

		public InventoryTransactionService(IInventoryTransactionRepository inventoryTransactionRepository)
		{
			_inventoryTransactionRepository = inventoryTransactionRepository;
		}

		public async Task<InventoryTransactionDto> CreateAsync(CreateInventoryTransactionRequestDto inventoryTransactionDto)
		{
			var inventoryTransactionModel = inventoryTransactionDto.ToInventoryTransactionFromCreateDTO();

			await _inventoryTransactionRepository.CreateAsync(inventoryTransactionModel);

			return inventoryTransactionModel.ToInventoryTransactionDTO();
		}

		public async Task<InventoryTransactionDto?> DeleteAsync(Guid id)
		{
			var existingInventoryTransaction = await _inventoryTransactionRepository.DeleteAsync(id);
			return existingInventoryTransaction != null ? existingInventoryTransaction.ToInventoryTransactionDTO() : null;
		}

		public async Task<PagedResponse<IQueryable<InventoryTransactionDto>>> GetAllAsync(QueryObject query)
		{
            //var inventoryTransactions = await _inventoryTransactionRepository.GetAllAsync(query);
            //var inventoryTransactionsToDTO = inventoryTransactions.Select(it => it.ToInventoryTransactionDTO()).ToList();
            //return inventoryTransactionsToDTO;

            throw new NotImplementedException();
        }

		public async Task<InventoryTransactionDto?> GetByIdAsync(Guid id)
		{
			var existingInventoryTransaction = await _inventoryTransactionRepository.GetByIdAsync(id);
			return existingInventoryTransaction != null ? existingInventoryTransaction.ToInventoryTransactionDTO() : null;
		}

		public Task<InventoryTransactionDto> UpdateAsync()
		{
			throw new NotImplementedException();
		}
	}
}
