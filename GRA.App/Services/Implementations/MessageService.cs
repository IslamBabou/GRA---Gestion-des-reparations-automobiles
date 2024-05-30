using GRA.App.Services.Contracts;
using GRA.Models.Dtos;
using System.Net.Http.Json;
using System.Net;

namespace GRA.App.Services.Implementations
{
    public class MessageService :IMessageService
    {
        private readonly HttpClient _httpClient;

        public async Task<int> CreateMessage(MessageDto message)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Message/CreateMessage", message);

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
                    var returnMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status: {response.StatusCode} Message - {returnMessage}\"\r\n\r\n");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Échec de la communication avec l'API.", ex);
            }
        }

        public async Task<IEnumerable<MessageDto>?> GetAllMessages()
        {
            try
            {
                var response = await _httpClient.GetAsync("Message/GetAllMessages");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }
                    var messages = await response.Content.ReadFromJsonAsync<IEnumerable<MessageDto>>();

                    return messages;
                }
                else
                {
                    var returnMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status: {response.StatusCode} Message - {returnMessage}\"\r\n\r\n");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Échec de la communication avec l'API.", ex);
            }
        }

        public async Task MarkMessageAsRead(int messageId)
        {
            try
            {
                var response = await _httpClient.PutAsync($"Message/MarkMessageAsRead/{messageId}", null);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new Exception("Message non trouvé.");
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
