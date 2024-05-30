using GRA.App.Pages;
using GRA.App.Services.Contracts;
using GRA.Models.Dtos;
using System.Net.Http;
using System.Net;
using System.Net.Http.Json;

namespace GRA.App.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;
        public async Task<int> CreateCustomer(CustomerDto customer)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Customer/CreateCustomer", customer);

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

        public async Task DeleteCustomer(int customerId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"Customer/DeleteCustomer/{customerId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return;
                    }
                    else
                    {
                        throw new Exception("Erreur de supression de rendez-vous");
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Échec de la communication avec l'API.", ex);
            }
        }

        public async Task<IEnumerable<CustomerDto>?> GetAllCustomers()
        {
            try
            {
                var response = await _httpClient.GetAsync("Customer/GetAllCustomers");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }
                    var customers = await response.Content.ReadFromJsonAsync<IEnumerable<CustomerDto>>();

                    return customers;
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

        public async Task<CustomerDto?> GetCustomerById(int customerId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Customer/GetCustomerById/{customerId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }

                    var customer = await response.Content.ReadFromJsonAsync<CustomerDto>();
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

        public async Task<IEnumerable<CustomerDto>?> SearchCustomer(string SearchTerm)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Customer/SearchCustomer/{SearchTerm}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }

                    var customer = await response.Content.ReadFromJsonAsync<IEnumerable<CustomerDto>>();
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
