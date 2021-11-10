﻿using System;
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
        private LocationStore locationStore = LocationStore.GetInstance();

        public Command SearchBarTextChangedCommand { get; set; }
        public Command SearchButtonPressedCommand { get; set; }
        public ObservableCollection<PostalEntry> ItemsSourceSearchBar { get; set; }
        public ObservableCollection<LocationEntry> ItemsSourceFoundLocations { get; set; }
        private bool ignoreNextSearchTextChanged = false;

        public SearchPageModel()
        {
            ItemsSourceSearchBar = new ObservableCollection<PostalEntry>();
            ItemsSourceFoundLocations = new ObservableCollection<LocationEntry>();

            SearchBarTextChangedCommand = new Command(async () => await SearchBarTextChanged());
            SearchButtonPressedCommand = new Command(async () => await SearchButtonPressed());
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

        async Task SearchButtonPressed()
        {
            try
            {
                ItemsSourceFoundLocations.Clear();

                var items = await locationStore.GetItemsAsyncSearch(SearchText);

                foreach (var item in items)
                {
                    ItemsSourceFoundLocations.Add(item);
                }

                PostalListVisibility = false;
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
