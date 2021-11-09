using System;
using System.Collections.Generic;
using System.Text;
using FreiplatzApp.Models;
using System.Linq;

namespace FreiplatzApp.Services
{
    class LocationStore : StoreBase<LocationStore, LocationEntry>
    {

        public void init() {
            for (int i = 0; i< 100; i++)
            {
                _ = AddItemAsync(getRandomEntry());
            }
        }

        private LocationEntry getRandomEntry()
        {
            LocationEntry locationEntry = new LocationEntry();
            locationEntry.Name = RandomString(5);
            locationEntry.Description = RandomString(50);
            locationEntry.MinAge = random.Next(1, 10);
            locationEntry.MaxAge = random.Next(11, 18);
            locationEntry.Paragraphs.Add(Enums.Paragraphs.HEIMERZIEHUNG);
            locationEntry.Space = random.Next(1, 6);
            locationEntry.postalCode = PostalCodeStore.GetInstance().entries[random.Next(PostalCodeStore.GetInstance().entries.Count)].Code;
            locationEntry.TelephoneNumber = "01548408468";
            locationEntry.Website = RandomString(30);
            locationEntry.EMail = RandomString(15);

            return locationEntry;
        }

        private static Random random = new Random();
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
