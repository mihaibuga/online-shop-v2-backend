using OnlineShop.Application.DTOs.Stocks;
using OnlineShop.Application.Interfaces.BaseEntities;

namespace OnlineShop.Application.Interfaces.Stocks
{
    public interface IStockService : IBaseService<StockDto, CreateStockRequestDto>
	{
	}
}
