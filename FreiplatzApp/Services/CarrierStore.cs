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
            carrierEntry.PostalEntry = PostalCodeStore.GetInstance().entries[random.Next(PostalCodeStore.GetInstance().entries.Count)];
            carrierEntry.TelephoneNumber = "015237446577";
            carrierEntry.Website = RandomString(30);
            carrierEntry.EMail = RandomString(15);
            carrierEntry.Street = RandomString(20);


            //random typeOfCarrier
            Array values = Enum.GetValues(typeof(Enums.TypeOfCarrier));
            Enums.TypeOfCarrier randomCarrier = (Enums.TypeOfCarrier)values.GetValue(random.Next(values.Length-1)+1);
            carrierEntry.TypeOfCarrier = randomCarrier;

            for (int i = 0; i < random.Next(0,4); i++)
            {
                carrierEntry.Locations.Add(locationsStore.getRandomEntry(carrierEntry)); //NEU
            }

            return carrierEntry;
        }

        public CarrierEntry getExampleEntry()
        {
            CarrierEntry carrierEntry = new CarrierEntry();
            carrierEntry.Id = "1";
            carrierEntry.Description = "Seit mehr als zwanzig Jahren sind wir als gemeinnütziger und nach § 75 SGB VIII anerkannter Träger der freien Jugendhilfe in Berlin und Brandenburg erfolgreich engagiert.Die Hilfeangebote sind nach den Grundsätzen einer sozialräumlichen Orientierung organisiert und strukturiert. Dabei wird ein hohes Maß an Flexibilität bei der Planung und Durchführung der Hilfen gewährleistet, dies geschieht in enger Kooperation mit dem Jugendamt.";
            carrierEntry.CarrierName = "KJHV Berlin-Brandenburg";
            carrierEntry.PostalNumber = 13125;
            carrierEntry.TelephoneNumber = "03061390725";
            carrierEntry.Website = "www.kjhv-bb.de";
            carrierEntry.EMail = "info@kjhv-bb.de";
            carrierEntry.Street = "Hauptstraße 34";
            carrierEntry.TypeOfCarrier = Enums.TypeOfCarrier.RELIGIOUS;
            carrierEntry.Locations.Add(locationsStore.getExampleLocationOne(carrierEntry));
            carrierEntry.Locations.Add(locationsStore.getExampleLocationTwo(carrierEntry));
            carrierEntry.Locations.Add(locationsStore.getExampleLocationThree(carrierEntry));
            carrierEntry.Locations.Add(locationsStore.getExampleLocationFour(carrierEntry));
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
