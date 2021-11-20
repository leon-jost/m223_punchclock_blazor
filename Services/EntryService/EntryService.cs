using Blazored.LocalStorage;
using M223PunchclockBlazor.Poco.Entry;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace M223PunchclockBlazor.Services.EntryService
{
    public class EntryService : IEntryService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageService _localStorage;

        public EntryService(HttpClient httpClient, IConfiguration configuration, NavigationManager navigationManager, ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            _httpClient = httpClient;
            _configuration = configuration;
            _navigationManager = navigationManager;
        }

        // POST
        public async Task<bool> AddEntryAsync(PostEntry entry)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri($"{_configuration["punchclockApi:baseUrl"]}/entry"),
            };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", await _localStorage.GetItemAsync<string>("authToken"));

            PostEntry newEntry;
            if (entry.project.id is not null)
            {
                newEntry = new()
                {
                    checkIn = entry.checkIn,
                    checkOut = entry.checkOut,
                    category = new Category() { id = entry.category.id },
                    project = new Project() { id = entry.project.id }
                };
            }
            else
            {
                newEntry = new()
                {
                    checkIn = entry.checkIn,
                    checkOut = entry.checkOut,
                    category = new Category() { id = entry.category.id }
                };
            }

            requestMessage.Content = new StringContent(JsonSerializer.Serialize(newEntry), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(requestMessage);
            //var responseContent = await response.Content.ReadFromJsonAsync<User>();

            if (response.IsSuccessStatusCode == false)
            {
                return false;
            }

            return true;
        }

        // GET
        public async Task<List<Entry>> GetEntriesAsync()
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("GET"),
                RequestUri = new Uri($"{_configuration["punchclockApi:baseUrl"]}/entry"),
            };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", await _localStorage.GetItemAsync<string>("authToken"));

            var responseMessage = await _httpClient.SendAsync(requestMessage);

            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadFromJsonAsync<List<Entry>>();
            }

            if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigationManager.NavigateTo("/auth");
            }

            return null;
        }

        // GET 1
        public async Task<Entry> GetEntryAsync(int id)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("GET"),
                RequestUri = new Uri($"{_configuration["punchclockApi:baseUrl"]}/entry/{id}"),
            };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", await _localStorage.GetItemAsync<string>("authToken"));

            var responseMessage = await _httpClient.SendAsync(requestMessage);

            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadFromJsonAsync<Entry>();
            }

            if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigationManager.NavigateTo("/auth");
            }

            return null;
        }

        // PUT
        public async Task<bool> UpdateEntryAsync(Entry entry)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("PUT"),
                RequestUri = new Uri($"{_configuration["punchclockApi:baseUrl"]}/entry"),
            };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", await _localStorage.GetItemAsync<string>("authToken"));

            Entry updatedEntry;
            if (entry.project.id is not null)
            {
                updatedEntry = new()
                {
                    id = entry.id,
                    checkIn = entry.checkIn,
                    checkOut = entry.checkOut,
                    category = new Category() { id = entry.category.id },
                    project = new Project() { id = entry.project.id }
                };
            }
            else
            {
                updatedEntry = new()
                {
                    id = entry.id,
                    checkIn = entry.checkIn,
                    checkOut = entry.checkOut,
                    category = new Category() { id = entry.category.id }
                };
            }

            requestMessage.Content = new StringContent(JsonSerializer.Serialize(updatedEntry), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(requestMessage);
            //var responseContent = await response.Content.ReadFromJsonAsync<User>();

            if (response.IsSuccessStatusCode == false)
            {
                return false;
            }

            return true;
        }

        // DELETE
        public async Task<bool> DeleteEntryAsync(int id)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("DELETE"),
                RequestUri = new Uri($"{_configuration["punchclockApi:baseUrl"]}/entry/{id}"),
            };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", await _localStorage.GetItemAsync<string>("authToken"));
            //requestMessage.Content = new StringContent(JsonSerializer.Serialize(user));

            var response = await _httpClient.SendAsync(requestMessage);
            //var responseContent = await response.Content.ReadFromJsonAsync<User>();

            if (response.IsSuccessStatusCode == false)
            {
                return false;
            }

            return true;
        }
    }
}
