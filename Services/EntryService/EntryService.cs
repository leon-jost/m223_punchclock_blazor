using M223PunchclockBlazor.Poco.Entry;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace M223PunchclockBlazor.Services.EntryService
{
    public class EntryService : IEntryService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public EntryService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<List<Entry>> GetAllEntriesAsync()
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("GET"),
                RequestUri = new Uri($"{_configuration["punchclockApi:baseUrl"]}/entries"),
            };
            requestMessage.Headers.Add("Authorization", "Bearer " + "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3psaS5jaC9pc3N1ZXIiLCJ1cG4iOiJ6bGkiLCJncm91cHMiOlsiVXNlciIsIkFkbWluIl0sImJpcnRoZGF0ZSI6IjIwMDEtMDctMTMiLCJpYXQiOjE2MzcxMzc1OTYsImV4cCI6MTYzNzE0MTE5NiwianRpIjoiOTUyZDhhZGItNTRmZi00YTM3LTg0ZGItYWMyMjI2YTg0OTI0In0.GE9uQPUzZkqGJlunTcAC5pyjvfpLKiHXaiW2h_dsbefcJcPX38mBNn8cI2ipo4XQtBuivD7XqRBP-A-5qDXivL7V_eLxA_rp3HCvogOQp7fXiw6WTZubETMiynTNXgGU4Y9C3fxGcK_rOO63aP8dwa43YLaaQX2jrvrjTL_6agSM0egxDiCaOOr-CxNGJvRyLmjaFIg5QzfXHBfGZXIIChKSKepHT6MHmzu7cxfz8qgrmnknDpO04hscVxSooRXhQzCLZ756WeJ5_E0JsGdH_dMxGLlSDzxLt7vQeY0xrrzP6p_o6nRTAJqm8WTlZZGIB_o7VQXqBadH7pKUxdmeZw");

            var responseMessage = await _httpClient.SendAsync(requestMessage);
            return await responseMessage.Content.ReadFromJsonAsync<List<Entry>>();
        }
    }
}
