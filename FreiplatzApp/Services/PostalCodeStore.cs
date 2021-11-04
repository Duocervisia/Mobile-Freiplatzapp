using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using ExcelDataReader;

using FreiplatzApp.Models;
namespace FreiplatzApp.Services
{
    class PostalCodeStore : IDataStore<PostalEntry>
    {
        readonly List<PostalEntry> postalEntries;

        public PostalCodeStore()
        {
            
        }
        public void init()
        {

            // https://docs.microsoft.com/en-us/answers/questions/315756/import-and-read-xml-and-csv-file-data-in-xamarin-f.html
            using (var stream = File.Open("../Assets/plz_berlin.xlsx", FileMode.Open, FileAccess.Read))
            {
                //// Auto-detect format, supports:
                ////  - Binary Excel files (2.0-2003 format; *.xls)
                ////  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                //using (var reader = ExcelReaderFactory.CreateReader(stream))
                //{
                //    // Choose one of either 1 or 2:

                //    // 1. Use the reader methods
                //    do
                //    {
                //        while (reader.Read())
                //        {
                //            // reader.GetDouble(0);
                //        }
                //    } while (reader.NextResult());

                //    // 2. Use the AsDataSet extension method
                //    var result = reader.AsDataSet();

                //    // The result of each spreadsheet is in result.Tables
                //}
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
    }
}
