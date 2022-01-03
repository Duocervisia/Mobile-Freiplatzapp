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
        private CarrierStore carrierStore = CarrierStore.GetInstance();
        public static List<string> favoriteList = LocalStorage.favoriteLocationIds;
        public ObservableCollection<LocationEntry> foundLocations { get; set; }

        public FavoriteModel()
        {
            foundLocations = new ObservableCollection<LocationEntry>();
            _ = initFavorite();
        }

        public void callback()
        {
            List<string> newfavoriteList = LocalStorage.favoriteLocationIds;
            if (!favoriteList.Equals(newfavoriteList))
            {
                favoriteList = newfavoriteList;
                _ = initFavorite();
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