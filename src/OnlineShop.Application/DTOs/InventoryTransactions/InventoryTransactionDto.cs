using OnlineShop.Application.DTOs.BaseEntities;
using OnlineShop.Domain.Enums;

namespace OnlineShop.Application.DTOs.InventoryTransactions
{
    public class InventoryTransactionDto : IBaseEntityDto
	{
		public Guid Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public bool IsEnabled { get; set; }
		public Guid ProductVariantId { get; set; }
		public DateTime TransactionDate { get; set; }
		public TransactionType Type { get; set; }
		public int Quantity { get; set; }
		public string? Description { get; set; }
	}
}
