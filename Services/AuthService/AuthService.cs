using Blazored.LocalStorage;
using M223PunchclockBlazor.Poco.Auth;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace M223PunchclockBlazor.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly IConfiguration _configuration;

        public AuthService(HttpClient httpClient,
            ILocalStorageService localStorage,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _configuration = configuration;
        }

        public async Task<string> Login(LoginRequest userForAuthentication)
        {
            var data = new LoginRequest()
            {
                username = userForAuthentication.username,
                password = userForAuthentication.password
            };

            var authResult = await _httpClient.PostAsync($"{_configuration["punchclockApi:baseUrl"]}/auth/login", new StringContent(JsonSerializer.Serialize(data), System.Text.Encoding.UTF8, "application/json"));
            var authContent = await authResult.Content.ReadAsStringAsync();

            if (authResult.IsSuccessStatusCode == false)
            {
                return null;
            }

            await _localStorage.SetItemAsync("authToken", authContent);

            // funktionert aus irgendeinem grund nicht, keine zeit zum herausfinden
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", authContent);

            return authContent;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<string> Register(LoginRequest userToRegister)
        {
            var data = new LoginRequest()
            {
                username = userToRegister.username,
                password = userToRegister.password
            };

            var authResult = await _httpClient.PostAsync($"{_configuration["punchclockApi:baseUrl"]}/auth/register", new StringContent(JsonSerializer.Serialize(data), System.Text.Encoding.UTF8, "application/json"));
            var authContent = await authResult.Content.ReadAsStringAsync();

            if (authResult.IsSuccessStatusCode == false)
            {
                return null;
            }

            await _localStorage.SetItemAsync("authToken", authContent);

            return authContent;
        }
    }
}
