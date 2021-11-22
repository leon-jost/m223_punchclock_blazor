using Blazored.LocalStorage;
using M223PunchclockBlazor.Poco.Project;
using M223PunchclockBlazor.Services.ProjectService;
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

namespace M223PunchclockBlazor.Services.UserService
{
    public class ProjectService : IProjectService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageService _localStorage;

        public ProjectService(HttpClient httpClient, IConfiguration configuration, NavigationManager navigationManager, ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            _httpClient = httpClient;
            _configuration = configuration;
            _navigationManager = navigationManager;
        }

        // POST
        public async Task<bool> AddProjectAsync(PostProject project)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri($"{_configuration["punchclockApi:baseUrl"]}/project"),
            };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", await _localStorage.GetItemAsync<string>("authToken"));
            requestMessage.Content = new StringContent(JsonSerializer.Serialize(project), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(requestMessage);
            //var responseContent = await response.Content.ReadFromJsonAsync<User>();

            if (response.IsSuccessStatusCode == false)
            {
                return false;
            }

            return true;
        }

        // GET
        public async Task<List<Project>> GetProjectsAsync()
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("GET"),
                RequestUri = new Uri($"{_configuration["punchclockApi:baseUrl"]}/project"),
            };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", await _localStorage.GetItemAsync<string>("authToken"));

            var responseMessage = await _httpClient.SendAsync(requestMessage);

            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadFromJsonAsync<List<Project>>();
            }

            if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigationManager.NavigateTo("/auth");
            }

            return null;
        }

        // GET 1
        public async Task<Project> GetProjectAsync(int? id)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("GET"),
                RequestUri = new Uri($"{_configuration["punchclockApi:baseUrl"]}/project/{id}"),
            };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", await _localStorage.GetItemAsync<string>("authToken"));

            var responseMessage = await _httpClient.SendAsync(requestMessage);

            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadFromJsonAsync<Project>();
            }

            if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigationManager.NavigateTo("/auth");
            }

            return null;
        }

        // PUT
        public async Task<bool> UpdateProjectAsync(Project project)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("PUT"),
                RequestUri = new Uri($"{_configuration["punchclockApi:baseUrl"]}/project"),
            };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", await _localStorage.GetItemAsync<string>("authToken"));
            requestMessage.Content = new StringContent(JsonSerializer.Serialize(project), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(requestMessage);
            //var responseContent = await response.Content.ReadFromJsonAsync<User>();

            if (response.IsSuccessStatusCode == false)
            {
                return false;
            }

            return true;
        }

        // DELETE
        public async Task<bool> DeleteProjectAsync(int? id)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("DELETE"),
                RequestUri = new Uri($"{_configuration["punchclockApi:baseUrl"]}/project/{id}"),
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
