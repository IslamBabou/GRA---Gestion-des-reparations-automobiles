using GRA.App.Services.Contracts;
using GRA.Models.Dtos;
using System.Net.Http;
using System.Net;
using System.Net.Http.Json;
using System.Collections.Generic;

namespace GRA.App.Services.Implementations
{
    public class StockService : IStockService
    {
        private readonly HttpClient _httpClient;
        public async Task<int> CreateStock(StockDto stock)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Stock/CreateStock", stock);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default;
                    }
                    return await response.Content.ReadFromJsonAsync<int>();
                }
                else
                {
                    var Message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status: {response.StatusCode} Message - {Message}\"\r\n\r\n");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Échec de la communication avec l'API.", ex);
            }
        }

        public async Task DeleteStock(int stockId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"Stock/DeleteStock/{stockId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return;
                    }
                    else
                    {
                        throw new Exception("Erreur de supression de produit");
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Échec de la communication avec l'API.", ex);
            }
        }

        public async Task<IEnumerable<StockDto>?> GetAllStocks()
        {
            try
            {
                var response = await _httpClient.GetAsync("Stock/GetAllStocks");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }
                    var stocks = await response.Content.ReadFromJsonAsync<IEnumerable<StockDto>>();

                    return stocks;
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status: {response.StatusCode} Message - {message}\"\r\n\r\n");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Échec de la communication avec l'API.", ex);
            }
        }

        public async Task<IEnumerable<StockDto>?> GetLowsStocks()
        {
            try
            {
                var response = await _httpClient.GetAsync("Stock/GetLowsStocks");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }
                    var stocks = await response.Content.ReadFromJsonAsync<IEnumerable<StockDto>>();

                    return stocks;
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status: {response.StatusCode} Message - {message}\"\r\n\r\n");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Échec de la communication avec l'API.", ex);
            }
        }

        public async Task<StockDto?> GetStockById(int stockId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Stock/GetStockById/{stockId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }

                    var stock = await response.Content.ReadFromJsonAsync<StockDto>();
                    return stock;
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status: {response.StatusCode} Message - {message}\"\r\n\r\n");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Échec de la communication avec l'API.", ex);
            }
        }

        public async Task<IEnumerable<StockDto>?> SearchStocks(string searchTerm)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Stock/SearchStocks/{searchTerm}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }

                    var stock = await response.Content.ReadFromJsonAsync<IEnumerable<StockDto>>();
                    return stock;
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status: {response.StatusCode} Message - {message}\"\r\n\r\n");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Échec de la communication avec l'API.", ex);
            }
        }
    }
}
