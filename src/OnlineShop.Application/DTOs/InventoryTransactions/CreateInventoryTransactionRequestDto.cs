using OnlineShop.Application.DTOs.BaseEntities;
using OnlineShop.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.DTOs.InventoryTransactions
{
    public class CreateInventoryTransactionRequestDto : ICreateBaseEntityRequestDto
	{
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime? ModifiedDate { get; set; } = DateTime.Now;
		public bool IsEnabled { get; set; } = true;
		[Required]
		public Guid ProductVariantId { get; set; }
		[Required]
		public DateTime TransactionDate { get; set; }
		[Required]
		public TransactionType Type { get; set; }
		[Required]
		public int Quantity { get; set; }
		public string? Description { get; set; }

	}
}
