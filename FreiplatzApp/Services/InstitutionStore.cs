using System;
using System.Collections.Generic;
using System.Text;
using FreiplatzApp.Models;
using System.Threading.Tasks;
using System.Linq;

namespace FreiplatzApp.Services
{
    class InstitutionStore : StoreBase<InstitutionStore, InstitutionEntry>
    {
        LocationStore locationsStore = LocationStore.GetInstance();

        public void init()
        {
            for (int i = 0; i < 500; i++)
            {
                _ = AddItemAsync(getRandomEntry());
            }
        }

        private InstitutionEntry getRandomEntry()
        {
            InstitutionEntry institutionEntry = new InstitutionEntry();
            institutionEntry.Id = GenerateSeededGuid().ToString();
            institutionEntry.Description = RandomString(50);
            institutionEntry.Name = RandomString(10);
            for(int i = 0; i < random.Next(0,4); i++)
            {
                institutionEntry.Locations.Add(locationsStore.getRandomEntry());
            }

            return institutionEntry;
        }

        public async Task<List<LocationEntry>> GetAsyncFoundLocations(FilterEntry filter, string searchText = null)
        {
            List<LocationEntry> foundLocationEntries = new List<LocationEntry>();
            if (string.IsNullOrEmpty(searchText))
                return await Task.FromResult(foundLocationEntries);

            searchText = searchText.ToLower();

            entries.ForEach(entry => {
                foundLocationEntries.AddRange(entry.getSearchLocations(searchText, filter));
            });

            return await Task.FromResult(foundLocationEntries);
        }
    }
}
