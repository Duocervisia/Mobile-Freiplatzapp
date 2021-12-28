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
            thisLocationTile.checkFavorite(null, true);
        }

        public LocationEntry Location
        {
            get { return (LocationEntry)GetValue(LocationProperty); }
            set { SetValue(LocationProperty, value); }
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
            checkFavorite(favs);

            LocalStorage.favoriteLocationIds = favs;
        }

        public void checkFavorite(List<string> favs = null, bool init = false)
        {
            Image image = this.FindByName<Image>("favoriteImage");

            favs = (favs == null) ? LocalStorage.favoriteLocationIds : favs;

            string imageSource = favs.Contains(Location.Id) ? imageSource = "favoritewhite36.png" : "favoriteborderwhite36.png";
       
            if (!init)
            {
                Animator.ImageTransition(image, imageSource);
            }
            else
            {
                image.Source = imageSource;
            }

        }

        private async void loc_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailPage(Location));
        }
    }
}