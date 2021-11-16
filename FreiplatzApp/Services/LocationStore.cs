using System;
using System.Collections.Generic;
using System.Text;
using FreiplatzApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace FreiplatzApp.Services
{
    class LocationStore : StoreBase<LocationStore, LocationEntry>
    {

        public void init() {
            for (int i = 0; i< 500; i++)
            {
                _ = AddItemAsync(getRandomEntry());
            }
        }

        private LocationEntry getRandomEntry()
        {
            LocationEntry locationEntry = new LocationEntry();
            locationEntry.Id = GenerateSeededGuid().ToString();
            locationEntry.Name = RandomString(5);
            locationEntry.Description = RandomString(50);
            locationEntry.MinAge = random.Next(1, 10);
            locationEntry.MaxAge = random.Next(11, 18);
            locationEntry.Paragraphs.Add(Enums.Paragraphs.HEIMERZIEHUNG);
            locationEntry.Space = random.Next(1, 6);
            locationEntry.PostalEntry = PostalCodeStore.GetInstance().entries[random.Next(PostalCodeStore.GetInstance().entries.Count)];
            locationEntry.TelephoneNumber = "01548408468";
            locationEntry.Website = RandomString(30);
            locationEntry.EMail = RandomString(15);

            return locationEntry;
        }

        private static Random random = new Random(1);
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public Guid GenerateSeededGuid()
        {
            var guid = new byte[16];
            random.NextBytes(guid);
            return new Guid(guid);
        }

        public async Task<IEnumerable<LocationEntry>> GetItemsAsyncSearch(string searchText = null)
        {
            if (string.IsNullOrEmpty(searchText))
                return await Task.FromResult(entries);
            searchText = searchText.ToLower();
            return await Task.FromResult(entries.Where(p => p.IsInSearch(searchText)));
        }
    }
}
