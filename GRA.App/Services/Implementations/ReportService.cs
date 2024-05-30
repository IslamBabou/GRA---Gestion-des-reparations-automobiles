using GRA.App.Services.Contracts;
using GRA.Models.Dtos;
using System.Net.Http;
using System.Net;
using System.Net.Http.Json;

namespace GRA.App.Services.Implementations
{
    public class ReportService : IReportService
    {
        private readonly HttpClient _httpClient;
        public async Task ArchiverReport(int reportId)
        {
            try
            {
                var response = await _httpClient.PutAsync($"ArchiverReport/{reportId}", null);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new Exception("Raport non trouvé.");
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Échec de la communication avec l'API.", ex);
            }
        }

        public async Task<int> CreateReport(ReportDto report)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Report/CreateReport", report);

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

        public async Task<IEnumerable<ReportDto>?> GetAllReports()
        {
            try
            {
                var response = await _httpClient.GetAsync("Report/GetAllReports");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }
                    var reports = await response.Content.ReadFromJsonAsync<IEnumerable<ReportDto>>();

                    return reports;
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

        public async Task<IEnumerable<ReportDto>?> GetReportByCustomerId(int vehicleId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Report/GetReportByCustomerId/{vehicleId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }

                    var report = await response.Content.ReadFromJsonAsync<IEnumerable<ReportDto>>();
                    return report;
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

        public async Task<ReportDto?> GetReportById(int reportId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Report/GetReportById/{reportId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }

                    var report = await response.Content.ReadFromJsonAsync<ReportDto>();
                    return report;
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

        public async Task<IEnumerable<ReportDto>?> GetReportByVehicleId(int vehicleId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Report/GetReportByVehicleId/{vehicleId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }

                    var reports = await response.Content.ReadFromJsonAsync<IEnumerable<ReportDto>>();
                    return reports;
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

        public async Task<int> GetReportsCount()
        {
            try
            {
                var response = await _httpClient.GetAsync("Report/GetReportsCount}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default;
                    }

                    var count = await response.Content.ReadFromJsonAsync<int>();
                    return count;
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
