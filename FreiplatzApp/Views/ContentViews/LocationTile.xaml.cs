using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FreiplatzApp.Models;
using FreiplatzApp.Helper;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FreiplatzApp.Views.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationTile : ContentView
    {
        public LocationTile()
        {
            InitializeComponent();
            Content.BindingContext = this;
        }


        public static readonly BindableProperty LocationProperty =
        BindableProperty.Create(
            propertyName: nameof(Location),
            returnType: typeof(LocationEntry),
            declaringType: typeof(LocationTile),
            propertyChanged: locationPropertyChanged);

      
        public static void locationPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            LocationTile thisLocationTile = bindable as LocationTile;
            thisLocationTile.checkFavText();
        }

        public LocationEntry Location
        {
            get { return (LocationEntry)GetValue(LocationProperty); }
            set { SetValue(LocationProperty, value); }
        }

        public static readonly BindableProperty FavTextroperty =
        BindableProperty.Create(nameof(FavText), typeof(string), typeof(LocationTile), null, BindingMode.TwoWay);

        public string FavText
        {
            get { return (string)GetValue(FavTextroperty); }
            set { SetValue(FavTextroperty, value); }
        }

        private void fav_Clicked(object sender, EventArgs e)
        {
            List<string> favs = LocalStorage.favoriteLocationIds;
            if(favs.Contains(Location.Id))
            {
                favs.Remove(Location.Id);
            }
            else
            {
                favs.Add(Location.Id);
            }
            checkFavText(favs);

            LocalStorage.favoriteLocationIds = favs;
        }

        public void checkFavText(List<string> favs = null)
        {
            favs = (favs == null) ? LocalStorage.favoriteLocationIds : favs;

            if (favs.Contains(Location.Id))
            {
                FavText = "-fav";
            }
            else
            {
                FavText = "+fav";
            }
        }
    }
}