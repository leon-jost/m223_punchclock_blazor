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
        private HttpClient HttpClient { get; set; }

        [Inject]
        private IEntryService EntryService { get; set; }

        private List<Entry> _entries { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _entries = await EntryService.GetAllEntriesAsync();
        }
    }
}
