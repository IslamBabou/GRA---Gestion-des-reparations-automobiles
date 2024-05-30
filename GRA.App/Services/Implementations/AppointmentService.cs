using GRA.App.Pages;
using GRA.App.Services.Contracts;
using GRA.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace GRA.App.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly HttpClient _httpClient;

        public AppointmentService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("ServerApi");
        }
        public async Task AssignMechanic(AppointmentDto appointment)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"Appointment/AssignMechanic", appointment);

                if (response.IsSuccessStatusCode)
                {

                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return;
                    }
                    else
                    {
                        var message = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Http status: {response.StatusCode} Message - {message}\"\r\n\r\n");
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Échec de la communication avec l'API.", ex);
            }
        }

        public async Task<int> CountAppointmentsByMechanicToday(int mechanicId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Appointment/CountAppointmentsByMechanicToday/{mechanicId}");

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

        public async Task<int> CreateAppointment(AppointmentDto appointment)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Appointment/CreateAppointment", appointment);
             
                if (response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default;
                    }
                    var result = await response.Content.ReadFromJsonAsync<int>();
                    return result;
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

        public async Task DeleteAppointment(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"Appointment/DeleteAppointment/{id}");
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
    

        public async Task<IEnumerable<AppointmentDto>?> GetAllAppointments()
        {
            try
            {
                var response = await _httpClient.GetAsync("Appointment/GetAllAppointments");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }
                    var appointments = await response.Content.ReadFromJsonAsync<IEnumerable<AppointmentDto>>();

                    return appointments;
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

        public async Task<IEnumerable<AppointmentsDetailsDto>?> GetAllAppointmentsDetails()
        {
            try
            {
                var response = await _httpClient.GetAsync("Appointment/GetAllAppointmentsDetails");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }
                    var appointments = await response.Content.ReadFromJsonAsync<IEnumerable<AppointmentsDetailsDto>>();

                    return appointments;
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

        public async Task<AppointmentsDetailsDto?> GetAppointmentById(int appointmentid)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Appointment/GetAppointmentById/{appointmentid}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }

                    var appointment = await response.Content.ReadFromJsonAsync<AppointmentsDetailsDto>();
                    return appointment;
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

        public async Task<IEnumerable<AppointmentsDetailsDto>?> GetTodayAppointments()
        {
            try
            {
                var response = await _httpClient.GetAsync("Appointment/GetTodayAppointments");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }
                    var appointments = await response.Content.ReadFromJsonAsync<IEnumerable<AppointmentsDetailsDto>>();

                    return appointments;
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

        public async Task<IEnumerable<AppointmentsDetailsDto>?> GetUncompletedAppointments()
        {
            try
            {
                var response = await _httpClient.GetAsync("Appointment/GetUncompletedAppointments");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }
                    var appointments = await response.Content.ReadFromJsonAsync<IEnumerable<AppointmentsDetailsDto>>();

                    return appointments;
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

        public async Task UpdateCompletedAppointmentById(int appointmentId)
        {
            try
            {
                var response = await _httpClient.PutAsync($"Appointment/UpdateCompletedAppointmentById/{appointmentId}", null);  
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new Exception("Rendez-vous non trouvé."); 
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
    }
}
