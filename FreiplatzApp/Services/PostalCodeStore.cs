using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Xamarin.Essentials;
using FreiplatzApp.Models;

namespace FreiplatzApp.Services
{
    class PostalCodeStore : StoreBase<PostalCodeStore, PostalEntry>
    {
        public async Task<bool> init()
        {
            using (var stream = await FileSystem.OpenAppPackageFileAsync("Files/plz_berlin.json"))
            {
                using (var reader = new StreamReader(stream))
                {
                    string fileContents = await reader.ReadToEndAsync();
                    entries = JsonConvert.DeserializeObject<List<PostalEntry>>(fileContents);
                    return true;
                }
            }
        }

        public async Task<IEnumerable<PostalEntry>> GetItemsAsyncSearch(string searchText = null)
        {
            if (string.IsNullOrEmpty(searchText))
                return await Task.FromResult(entries);
            searchText = searchText.ToLower();
            return await Task.FromResult(entries.Where(p => p.IsInSearch(searchText)));
        }
    }
}
