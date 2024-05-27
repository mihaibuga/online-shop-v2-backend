using OnlineShop.Application.DTOs.Stocks;
using OnlineShop.Application.Interfaces.Stocks;
using OnlineShop.Application.Mappers;

namespace OnlineShop.Application.Services
{
	public class StockService : IStockService
	{
		private readonly IStockRepository _stockRepository;

		public StockService(IStockRepository stockRepository)
		{
			_stockRepository = stockRepository;
		}

		public async Task<StockDto> CreateAsync(CreateStockRequestDto stockDto)
		{
			var stockModel = stockDto.ToStockFromCreateDTO();

			await _stockRepository.CreateAsync(stockModel);

			return stockModel.ToStockDTO();
		}

		public async Task<StockDto?> DeleteAsync(Guid id)
		{
			var existingStock = await _stockRepository.DeleteAsync(id);
			return existingStock != null ? existingStock.ToStockDTO() : null;
		}

		public async Task<List<StockDto>> GetAllAsync()
		{
			var stocks = await _stockRepository.GetAllAsync();
			var stocksToDTO = stocks.Select(s => s.ToStockDTO()).ToList();
			return stocksToDTO;
		}

		public async Task<StockDto?> GetByIdAsync(Guid id)
		{
			var existingStock = await _stockRepository.GetByIdAsync(id);
			return existingStock != null ? existingStock.ToStockDTO() : null;
		}

		public Task<StockDto> UpdateAsync()
		{
			throw new NotImplementedException();
		}
	}
}
