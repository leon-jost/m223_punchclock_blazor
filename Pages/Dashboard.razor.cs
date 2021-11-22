using M223PunchclockBlazor.Poco.Entry;
using M223PunchclockBlazor.Poco.Project;
using M223PunchclockBlazor.Services.CategoryService;
using M223PunchclockBlazor.Services.EntryService;
using M223PunchclockBlazor.Services.ProjectService;
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
        [Inject]
        private IProjectService ProjectService { get; set; }
        [Inject]
        private ICategoryService CategoryService { get; set; }

        private List<Entry> _entries { get; set; }
        private List<Poco.Project.Project> _projects { get; set; }
        private List<Category> _categories { get; set; }

        private PostEntry _newEntry = new() { category = new Category(), project = new Poco.Entry.Project() };

        protected override async Task OnInitializedAsync()
        {
            _entries = await EntryService.GetEntriesAsync();
            _projects = await ProjectService.GetProjectsAsync();
            _categories = await CategoryService.GetCategoriesAsync();
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
