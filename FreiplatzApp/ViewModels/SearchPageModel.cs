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
        private PostalCodeStore postalCodeStore = PostalCodeStore.GetInstance();
        public Command SearchBarTextChangedCommand { get; set; }

        public SearchPageModel()
        {
            ItemsSourceSearchBar = new ObservableCollection<PostalEntry>();
            SearchBarTextChangedCommand = new Command(async () => await SearchBarTextChanged());
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value)
                {
                    SetProperty(ref _searchText, value);
                    if (!ignoreNextSearchTextChanged)
                    {
                        _ = SearchBarTextChanged();
                    }
                    else
                    {
                        ignoreNextSearchTextChanged = false;
                    }
                }
            }
        }

        public ObservableCollection<PostalEntry> ItemsSourceSearchBar { get; set; }
        private bool ignoreNextSearchTextChanged = false;
        private PostalEntry _selectedItemSearchBar;
        public PostalEntry SelectedItemSearchBar {
            get { return _selectedItemSearchBar; }
            set
            {
                if (_selectedItemSearchBar != value)
                {
                    SetProperty(ref _selectedItemSearchBar, value);
                    if (value != null)
                    {
                        ignoreNextSearchTextChanged = true;
                        SearchText = SearchText == "" || int.TryParse(SearchText, out _) ? _selectedItemSearchBar.Code.ToString() : _selectedItemSearchBar.District;
                        checkPostalListVisibility();
                    }
                }
            }
        }

        private bool _postalListVisibility = false;
        public bool PostalListVisibility
        {
            get { return _postalListVisibility; }
            set { SetProperty(ref _postalListVisibility, value); }
        }

        async Task SearchBarTextChanged()
        {
            try
            {
                SelectedItemSearchBar = null;
                ItemsSourceSearchBar.Clear();

                var items = await postalCodeStore.GetItemsAsyncSearch(SearchText);

                foreach (var item in items)
                {
                    ItemsSourceSearchBar.Add(item);
                }

                checkPostalListVisibility();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        private void checkPostalListVisibility(){
            PostalListVisibility = ItemsSourceSearchBar.Count == 0 || SelectedItemSearchBar != null ? false : true;
        }
    }
}
