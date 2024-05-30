﻿using Blazored.SessionStorage;
using GRA.App.Services.Contracts;
using GRA.Models.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;

namespace GRA.App.Services.Implementations
{
    public class AuthService : IAuthService
    {   private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _factory;
        private ISessionStorageService _sessionStorageService;
        private const string JWT_KEY = nameof(JWT_KEY);
        private string? _jwtCache;

        public event Action<string?>? LoginChange; // userId (int?) or null

        public AuthService(IHttpClientFactory factory, ISessionStorageService sessionStorageService)
        {
            _factory = factory;
            _sessionStorageService = sessionStorageService;
        }

        public async ValueTask<string> GetJwtAsync()
        {
            if (string.IsNullOrEmpty(_jwtCache))
                _jwtCache = await _sessionStorageService.GetItemAsync<string>(JWT_KEY);

            return _jwtCache;
        }

        public async Task LogoutAsync()
        {
            await _sessionStorageService.RemoveItemAsync(JWT_KEY);

            _jwtCache = null;

            LoginChange?.Invoke(null);
        }

        public async Task RegisterUser(UserForRegistrationDto userForRegistration)
        {
            try
            {
                var response = await _factory.CreateClient("ServerApi")
                    .PostAsJsonAsync<UserForRegistrationDto>("Auth/Register", userForRegistration);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<DateTime> LoginAsync(UserForLoginDto userForLogin)
        {
            var response = await _factory.CreateClient("ServerApi").PostAsync("Auth/Login", JsonContent.Create(userForLogin));

            if (!response.IsSuccessStatusCode)
                throw new UnauthorizedAccessException("La connexion a échoué.");

            var content = await response.Content.ReadFromJsonAsync<LoginResponse>();

            if (content == null)
                throw new InvalidDataException();

            await _sessionStorageService.SetItemAsync(JWT_KEY, content.JwtToken);

            LoginChange?.Invoke(GetUsername(content.JwtToken));

            return content.Expiration;
        }

        private static string GetUsername(string token)
        {
            var jwt = new JwtSecurityToken(token);

            return jwt.Claims.First(c => c.Type == ClaimTypes.Name).Value;
        }

        public async Task<IEnumerable<UserDto>?> GetAllUsers()
        {
            try
            {
                var response = await _httpClient.GetAsync("User/GetAllUsers");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default;
                    }
                    var users = await response.Content.ReadFromJsonAsync<IEnumerable<UserDto>>();

                    return users;
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
    }
}