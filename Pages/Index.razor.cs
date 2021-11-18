using Blazored.LocalStorage;
using M223PunchclockBlazor.Poco.Entry;
using M223PunchclockBlazor.Services.EntryService;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace M223PunchclockBlazor.Pages
{
    public partial class Index
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private ILocalStorageService LocalStorage { get; set; }

        protected async override Task OnInitializedAsync()
        {
            if (await LocalStorage.ContainKeyAsync("authToken"))
            {
                NavigationManager.NavigateTo("/dashboard");
            }
            else
            {
                NavigationManager.NavigateTo("/auth");
            }
        }
    }
}
