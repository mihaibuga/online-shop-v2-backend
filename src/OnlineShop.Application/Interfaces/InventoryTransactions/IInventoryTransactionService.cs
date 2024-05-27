using OnlineShop.Application.DTOs.InventoryTransactions;

namespace OnlineShop.Application.Interfaces.InventoryTransactions
{
	public interface IInventoryTransactionService : IBaseService<InventoryTransactionDto, CreateInventoryTransactionRequestDto>
	{
	}
}
