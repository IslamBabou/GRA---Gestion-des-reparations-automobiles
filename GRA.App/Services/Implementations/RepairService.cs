using GRA.App.Services.Contracts;
using GRA.Models.Dtos;
using System.Net.Http;
using System.Net;
using System.Net.Http.Json;

namespace GRA.App.Services.Implementations
{
    public class RepairService : IRepairService
    {
        private readonly HttpClient _httpClient;
        public RepairService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("ServerApi");
        }
        public async Task<int> CreateRepair(AddOrUpdateRepairDto repair)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Repair/CreateRepair", repair);

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
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status: {response.StatusCode} Message - {message}\"\r\n\r\n");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Échec de la communication avec l'API.", ex);
            }
        }

        public async Task<IEnumerable<RepairDto>?> GetAllRepair()
        {
            try
            {
                var response = await _httpClient.GetAsync("Repair/GetAllRepair");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }
                    var repairs = await response.Content.ReadFromJsonAsync<IEnumerable<RepairDto>>();

                    return repairs;
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
        public async Task<IEnumerable<RepairDto>?> GetRepairByCustomerId(int customerId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Repair/GetRepairByCustomerId/{customerId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }

                    var customer = await response.Content.ReadFromJsonAsync<IEnumerable<RepairDto>>();
                    return customer;
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

        public async Task<AddOrUpdateRepairDto?> GetRepairById(int repairId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Repair/GetRepairById/{repairId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }

                    var repair = await response.Content.ReadFromJsonAsync<AddOrUpdateRepairDto>();
                    return repair;
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

        public async Task<IEnumerable<RepairDto>?> GetRepairByNumberPlate(string numberPlate)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Repair/GetRepairByNumberPlate/{numberPlate}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }

                    var customer = await response.Content.ReadFromJsonAsync<IEnumerable<RepairDto>>();
                    return customer;
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
