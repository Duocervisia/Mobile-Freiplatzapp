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
    class PostalCodeStore : IDataStore<PostalEntry>
    {
        //single instance used everywhere.
        private static PostalCodeStore _instance;

        //private constructor so only the GetInstance() method can create an instance of this object.
        private PostalCodeStore()
        {

        }

        //get single instance
        public static PostalCodeStore GetInstance()
        {
            if (_instance != null) return _instance;
            return _instance = new PostalCodeStore();
        }

        public List<PostalEntry> postalEntries;

        public async void init()
        {

            using (var stream = await FileSystem.OpenAppPackageFileAsync("Files/plz_berlin.json"))
            {
                using (var reader = new StreamReader(stream))
                {
                    string fileContents = await reader.ReadToEndAsync();
                    postalEntries = JsonConvert.DeserializeObject<List<PostalEntry>>(fileContents);

                }
            }
        }

        public async Task<bool> AddItemAsync(PostalEntry postalEntry)
        {
            postalEntries.Add(postalEntry);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(PostalEntry postalEntry)
        {
            var oldPostalEntry = postalEntries.Where((PostalEntry arg) => arg.Code == postalEntry.Code).FirstOrDefault();
            postalEntries.Remove(oldPostalEntry);
            postalEntries.Add(postalEntry);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldPostalEntry = postalEntries.Where((PostalEntry arg) => arg.Id == id).FirstOrDefault();
            postalEntries.Remove(oldPostalEntry);

            return await Task.FromResult(true);
        }

        public async Task<PostalEntry> GetItemAsync(string id)
        {
            return await Task.FromResult(postalEntries.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<PostalEntry>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(postalEntries);
        }
        public async Task<IEnumerable<PostalEntry>> GetItemsAsyncSearch(string searchText = null)
        {
            if (string.IsNullOrEmpty(searchText))
                return await Task.FromResult(postalEntries);
            searchText = searchText.ToLower();
            return await Task.FromResult(postalEntries.Where(p => p.District.ToLower().Contains(searchText) || p.Code.ToString().Contains(searchText)));
        }
    }
}
