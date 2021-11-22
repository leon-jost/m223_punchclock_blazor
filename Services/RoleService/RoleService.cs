using Blazored.LocalStorage;
using M223PunchclockBlazor.Poco.Entry;
using M223PunchclockBlazor.Poco.Role;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace M223PunchclockBlazor.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageService _localStorage;

        public RoleService(HttpClient httpClient, IConfiguration configuration, NavigationManager navigationManager, ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            _httpClient = httpClient;
            _configuration = configuration;
            _navigationManager = navigationManager;
        }

        // GET
        public async Task<List<Role>> GetRolesAsync()
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("GET"),
                RequestUri = new Uri($"{_configuration["punchclockApi:baseUrl"]}/role"),
            };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", await _localStorage.GetItemAsync<string>("authToken"));

            var responseMessage = await _httpClient.SendAsync(requestMessage);

            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadFromJsonAsync<List<Role>>();
            }

            if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigationManager.NavigateTo("/auth");
            }

            return null;
        }
    }
}
