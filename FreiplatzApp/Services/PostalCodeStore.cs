using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using ExcelDataReader;
using Xamarin.Essentials;
using FreiplatzApp.Models;

namespace FreiplatzApp.Services
{
    class PostalCodeStore : StoreBase<PostalCodeStore, PostalEntry>
    {
        public async void init()
        {

            using (var stream = await FileSystem.OpenAppPackageFileAsync("Files/plz_berlin.json"))
            {
                using (var reader = new StreamReader(stream))
                {
                    string fileContents = await reader.ReadToEndAsync();
                    entries = JsonConvert.DeserializeObject<List<PostalEntry>>(fileContents);
                    LocationStore.GetInstance().init();
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
