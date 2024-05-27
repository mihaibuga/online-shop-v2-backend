using OnlineShop.Application.DTOs.InventoryTransactions;
using OnlineShop.Application.Interfaces.BaseEntities;

namespace OnlineShop.Application.Interfaces.InventoryTransactions
{
    public interface IInventoryTransactionService : IBaseService<InventoryTransactionDto, CreateInventoryTransactionRequestDto>
	{
	}
}
