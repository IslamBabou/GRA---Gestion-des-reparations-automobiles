using GRA.App.Pages.Manager;
using GRA.App.Services.Contracts;
using GRA.Models.Dtos;
using System.Net.Http;
using System.Net;
using System.Net.Http.Json;

namespace GRA.App.Services.Implementations
{
    public class VehicleService : IVehicleService
    {   
        private readonly HttpClient _httpClient;
        public async Task<int> CreateVehicle(VehicleDto vehicle)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Vehicle/CreateVehicle", vehicle);

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

        public async Task<IEnumerable<VehicleDto>?> GetAllVehicles()
        {
            try
            {
                var response = await _httpClient.GetAsync("Vehicle/GetAllVehicles");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }
                    var vehicles = await response.Content.ReadFromJsonAsync<IEnumerable<VehicleDto>>();

                    return vehicles;
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

        public async Task<IEnumerable<VehicleDto>?> GetVehicleByCustomerId(int customerId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Vehicle/GetVehicleByCustomerId/{customerId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }

                    var vehicles = await response.Content.ReadFromJsonAsync<IEnumerable<VehicleDto>>();
                    return vehicles;
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

        public async Task<VehicleDto?> GetVehicleById(int vehicleId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Vehicle/GetVehicleById/{vehicleId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }

                    var vehicle = await response.Content.ReadFromJsonAsync<VehicleDto>();
                    return vehicle;
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

        public async Task<IEnumerable<VehicleDto>?> SearchVehicle(string SearchTerm)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Vehicle/SearchVehicle/{SearchTerm}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }

                    var vehicles = await response.Content.ReadFromJsonAsync<IEnumerable<VehicleDto>>();
                    return vehicles;
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

        public async Task UpdateVehicleFirstVisitById(VehicleDto vehicle)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Vehicle/UpdateVehicleFirstVisitById", vehicle);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return;
                    }
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
