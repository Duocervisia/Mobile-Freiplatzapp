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
        private InstitutionStore institutionStore = InstitutionStore.GetInstance();
        public ObservableCollection<LocationEntry> foundLocations { get; set; }
        

        public FavoriteModel()
        {
            foundLocations = new ObservableCollection<LocationEntry>();

            _=initFavorite();
        }


        async Task initFavorite()
        {
            try
            {
                var items = await institutionStore.GetLocationsByLocationIDs(LocalStorage.favoriteLocationIds);

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