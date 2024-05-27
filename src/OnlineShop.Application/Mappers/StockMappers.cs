using OnlineShop.Application.DTOs.Stocks;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Mappers
{
	public static class StockMappers
	{
		public static StockDto ToStockDTO(this Stock stockModel)
		{
			return new StockDto
			{
				Id = stockModel.Id,
				CreatedDate = stockModel.CreatedDate,
				ModifiedDate = stockModel.ModifiedDate,
				IsEnabled = stockModel.IsEnabled,
				ProductVariantId = stockModel.ProductVariantId,
				Quantity = stockModel.Quantity,
			};
		}

		public static Stock ToStockFromCreateDTO(this CreateStockRequestDto stockDTO)
		{
			return new Stock
			{
				CreatedDate = stockDTO.CreatedDate,
				ModifiedDate = stockDTO.ModifiedDate,
				IsEnabled = stockDTO.IsEnabled,
				ProductVariantId = stockDTO.ProductVariantId,
				Quantity = stockDTO.Quantity,
			};
		}
	}
}
