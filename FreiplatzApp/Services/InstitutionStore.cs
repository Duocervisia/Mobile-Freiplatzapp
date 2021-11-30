using System;
using System.Collections.Generic;
using System.Text;
using FreiplatzApp.Models;

namespace FreiplatzApp.Services
{
    class InstitutionStore : StoreBase<InstitutionStore, InstitutionEntry>
    {
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
                institutionEntry.Locations.Add(LocationStore.GetInstance().getRandomEntry());

            }

            return institutionEntry;
        }
    }
}
