using System;
using System.Collections.Generic;
using System.Text;
using FreiplatzApp.Models;
using System.Threading.Tasks;
using System.Linq;

namespace FreiplatzApp.Services
{
    class CarrierStore : StoreBase<CarrierStore, CarrierEntry>
    {
        LocationStore locationsStore = LocationStore.GetInstance();

        public void init()
        {
            for (int i = 0; i < 500; i++)
            {
                _ = AddItemAsync(getRandomEntry());
            }
        }

        public CarrierEntry getRandomEntry()
        {
            CarrierEntry carrierEntry = new CarrierEntry();
            carrierEntry.Id = GenerateSeededGuid().ToString();
            carrierEntry.Description = RandomString(50);
            carrierEntry.CarrierName = RandomString(10);

            //random typeOfCarrier
            Array values = Enum.GetValues(typeof(Enums.TypeOfCarrier));
            Enums.TypeOfCarrier randomCarrier = (Enums.TypeOfCarrier)values.GetValue(random.Next(values.Length-1)+1);
            carrierEntry.TypeOfCarrier = randomCarrier;

            for (int i = 0; i < random.Next(0,4); i++)
            {
                carrierEntry.Locations.Add(locationsStore.getRandomEntry());
            }

            return carrierEntry;
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
