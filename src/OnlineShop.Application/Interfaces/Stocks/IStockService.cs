using OnlineShop.Application.DTOs.Stocks;

namespace OnlineShop.Application.Interfaces.Stocks
{
	public interface IStockService : IBaseService<StockDto, CreateStockRequestDto>
	{
	}
}
