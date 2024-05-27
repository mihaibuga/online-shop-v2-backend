using OnlineShop.Application.DTOs.InventoryTransactions;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Mappers
{
	public static class InventoryTransactionMappers
	{
		public static InventoryTransactionDto ToInventoryTransactionDTO(this InventoryTransaction inventoryTransactionModel)
		{
			return new InventoryTransactionDto
			{
				Id = inventoryTransactionModel.Id,
				CreatedDate = inventoryTransactionModel.CreatedDate,
				ModifiedDate = inventoryTransactionModel.ModifiedDate,
				IsEnabled = inventoryTransactionModel.IsEnabled,
				TransactionDate = inventoryTransactionModel.TransactionDate,
				Type = inventoryTransactionModel.Type,
				Quantity = inventoryTransactionModel.Quantity,
				Description = inventoryTransactionModel.Description,
			};
		}

		public static InventoryTransaction ToInventoryTransactionFromCreateDTO(this CreateInventoryTransactionRequestDto inventoryTransactionDTO)
		{
			return new InventoryTransaction
			{
				CreatedDate = inventoryTransactionDTO.CreatedDate,
				ModifiedDate = inventoryTransactionDTO.ModifiedDate,
				IsEnabled = inventoryTransactionDTO.IsEnabled,
				TransactionDate = inventoryTransactionDTO.TransactionDate,
				Type = inventoryTransactionDTO.Type,
				Quantity = inventoryTransactionDTO.Quantity,
				Description = inventoryTransactionDTO.Description,
			};
		}
	}
}
