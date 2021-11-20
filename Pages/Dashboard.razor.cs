using M223PunchclockBlazor.Poco.Entry;
using M223PunchclockBlazor.Services.EntryService;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M223PunchclockBlazor.Pages
{
    public partial class Dashboard
    {
        [Inject]
        private IEntryService EntryService { get; set; }

        private List<Entry> _entries { get; set; }

        private PostEntry _newEntry = new() { category = new Category(), project = new Project() };

        protected override async Task OnInitializedAsync()
        {
            _entries = await EntryService.GetEntriesAsync();
        }

        public async Task DeleteEntryAsync(Entry entry)
        {
            await EntryService.DeleteEntryAsync(entry.id);
            _entries = await EntryService.GetEntriesAsync();
        }

        public async Task AddEntryAsync(PostEntry entry)
        {
            await EntryService.AddEntryAsync(entry);
            _entries = await EntryService.GetEntriesAsync();
        }

        public async Task UpdateEntryAsync(Entry entry)
        {
            await EntryService.UpdateEntryAsync(entry);
            _entries = await EntryService.GetEntriesAsync();
        }
    }
}
