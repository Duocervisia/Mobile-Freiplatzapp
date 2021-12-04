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
            FavText = "fav";
        }

        public static readonly BindableProperty LocationProperty =
        BindableProperty.Create(nameof(Location), typeof(LocationEntry), typeof(LocationTile));

        public LocationEntry Location
        {
            get { return (LocationEntry)GetValue(LocationProperty); }
            set { SetValue(LocationProperty, value); }
        }

        private string _favText;
        public string FavText
        {
            get { return _favText; }
            set {
                _favText = value;
                OnPropertyChanged("FavText");
            }
        }

        //private string favText
        //public string FavText
        //{
        //    get
        //    {
        //        List<string> favs = LocalStorage.favoriteLocationIds;
        //        if (Location != null && favs.Contains(Location.Id))
        //        {
        //            return "fav entfernen";
        //        }
        //        return "fav";
        //    }
        //    set { SetValue(LocationProperty, value); }

        //}

        private void fav_Clicked(object sender, EventArgs e)
        {
            List<string> favs = LocalStorage.favoriteLocationIds;
            if(favs.Contains(Location.Id))
            {
                favs.Remove(Location.Id);
                FavText = "fav";
            }
            else
            {
                favs.Add(Location.Id);
                FavText = "fav entfernen";
            }

            LocalStorage.favoriteLocationIds = favs;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler == null) return;
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}