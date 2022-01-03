using FreiplatzApp.Helper;
using FreiplatzApp.Models;
using FreiplatzApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FreiplatzApp.ViewModels
{
    public class FavoriteModel : ViewModelBase
    {
        public Command PageAppearingCommand { get; set; }
        private CarrierStore carrierStore = CarrierStore.GetInstance();
        public static List<string> favoriteList = LocalStorage.favoriteLocationIds;
        public ObservableCollection<LocationEntry> foundLocations { get; set; }

        public FavoriteModel()
        {
            PageAppearingCommand = new Command(() => OnAppearing());
            foundLocations = new ObservableCollection<LocationEntry>();
            _ = initFavorite();
        }

        private void OnAppearing()
        {
            List<string> newfavoriteList = LocalStorage.favoriteLocationIds;
            if(favoriteList != newfavoriteList) 
            {
                favoriteList = newfavoriteList;
                foundLocations.Clear();
                _ =initFavorite();
            }
        }

        async Task initFavorite()
        {
            try
            {
                var items = await carrierStore.GetLocationsByLocationIDs(favoriteList);

                foreach (var item in items)
                {
                    foundLocations.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}