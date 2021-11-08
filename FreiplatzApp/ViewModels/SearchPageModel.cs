using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FreiplatzApp.Models;
using FreiplatzApp.Services;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FreiplatzApp.ViewModels
{
    class SearchPageModel : ViewModelBase
    {
        // public IDataStore<PostalEntry> DataStorePostalEntries => DependencyService.Get<IDataStore<PostalEntry>>();
        private PostalCodeStore postalCodeStore = PostalCodeStore.GetInstance();
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                SetProperty(ref _searchText, value);
                SearchBarTextChanged();
            }
        }
        
        public ObservableCollection<PostalEntry> ItemsSourceSearchBar { get; set; }
        private PostalEntry _selectedItemSearchBar;
        public PostalEntry SelectedItemSearchBar{
            get { return _selectedItemSearchBar; }
            set
            {
                if (_selectedItemSearchBar != value)
                {
                    _selectedItemSearchBar = value;
                    SearchText = _selectedItemSearchBar.Code.ToString();
                }
            }
        }
        public Command SearchBarTextChangedCommand { get; set; }

        public SearchPageModel()
        {
            ItemsSourceSearchBar = new ObservableCollection<PostalEntry>();
            SearchBarTextChangedCommand = new Command(async () => await SearchBarTextChanged());
        }

        async Task SearchBarTextChanged()
        {
            Debug.WriteLine("beforeAll");

            try
            {
                ItemsSourceSearchBar.Clear();
                Debug.WriteLine("before Items Await");
                var items = await postalCodeStore.GetItemsAsyncSearch(SearchText);
                Debug.WriteLine("after Items Await");

                foreach (var item in items)
                {
                    ItemsSourceSearchBar.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
