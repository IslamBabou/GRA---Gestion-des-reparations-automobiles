using GRA.Models.Dtos;

namespace GRA.App.Services.Contracts
{
    public interface IStockService
    {
        Task<int> CreateStock(StockDto stock);
        Task DeleteStock(int stockId);
        Task<IEnumerable<StockDto>?> GetAllStocks();
        Task<StockDto?> GetStockById(int stockId);
        Task<IEnumerable<StockDto>?> GetLowsStocks();
        Task<IEnumerable<StockDto>?> SearchStocks(string searchTerm);
        
    }
}
