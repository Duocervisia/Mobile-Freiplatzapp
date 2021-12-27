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
    public partial class CarrierLocationTile : ContentView
    {
        public Command EditButtonPressedCommand { get; set; }
        public CarrierLocationTile()
        {
            InitializeComponent();
            Content.BindingContext = this;
            EditButtonPressedCommand = new Command((location) => EditButtonPressed(location));
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

        private void EditButtonPressed(object location)
        {

        }
    }
}