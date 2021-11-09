using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FreiplatzApp.Models;
using System.Linq;

namespace FreiplatzApp.Services
{
    abstract class StoreBase<DerivedClass, Model> where DerivedClass : new() where Model : ModelBase
    {
        public List<Model> entries = new List<Model>();

        //single instance used everywhere.
        public static DerivedClass _instance;

        //get single instance
        public static DerivedClass GetInstance()
        {
            if (_instance != null) return _instance;
            return _instance = new DerivedClass();
        }

        public async Task<bool> AddItemAsync(Model entry)
        {
            entries.Add(entry);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Model entry)
        {
            var oldEntry = entries.Where((Model arg) => arg.Id == entry.Id).FirstOrDefault();
            entries.Remove(oldEntry);
            entries.Add(entry);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldPostalEntry = entries.Where((Model arg) => arg.Id == id).FirstOrDefault();
            entries.Remove(oldPostalEntry);

            return await Task.FromResult(true);
        }

        public async Task<Model> GetItemAsync(string id)
        {
            return await Task.FromResult(entries.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Model>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(entries);
        }
    }
}
