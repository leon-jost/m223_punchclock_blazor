using M223PunchclockBlazor.Poco.Entry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M223PunchclockBlazor.Services.EntryService
{
    interface IEntryService
    {
        public Task<bool> AddEntryAsync(PostEntry entry);
        public Task<List<Entry>> GetEntriesAsync();
        public Task<Entry> GetEntryAsync(int id);
        public Task<bool> UpdateEntryAsync(Entry entry);
        public Task<bool> DeleteEntryAsync(int id);
    }
}
